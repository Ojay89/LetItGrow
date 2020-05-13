using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InMemoryDB.Model;

namespace InMemoryDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
            if (_context.InMemoryUsers.Count() == 0)
            {
                _context.InMemoryUsers.Add(new User(1, "kon", "pwd", "kon@kon.dk", new List<string>(){ "104800", "131981" }));
                _context.InMemoryUsers.Add(new User(2, "nik", "pwd", "nik@nik.dk", new List<string>(){ "136870", "168621" }));
                _context.InMemoryUsers.Add(new User(3, "dan", "pwd", "dan@dan.dk", new List<string>(){ "162791", "141410" }));


                _context.SaveChanges();
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetInMemoryUsers() 
        {
            return await _context.InMemoryUsers.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.InMemoryUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.InMemoryUsers.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.InMemoryUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.InMemoryUsers.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.InMemoryUsers.Any(e => e.Id == id);
        }
    }
}
