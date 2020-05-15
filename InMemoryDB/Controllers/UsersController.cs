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
                _context.InMemoryUsers.Add(new User("nikolaj", "pwd", "nik@nik.dk"));
                _context.InMemoryUsers.Add(new User("benjamin", "pwd", "ben@ben.dk"));
                _context.InMemoryUsers.Add(new User("sarah", "pwd", "sar@sar.dk"));
                _context.InMemoryUsers.Add(new User("anja", "pwd", "anj@anj.dk"));
                _context.InMemoryUsers.Add(new User("daniel", "pwd", "dan@dan.dk"));
                _context.SaveChanges();
                _context.InMemoryPlants.Add(new Plant(1, "153966"));
                _context.InMemoryPlants.Add(new Plant(1, "157820"));
                _context.InMemoryPlants.Add(new Plant(1, "151390"));
                _context.InMemoryPlants.Add(new Plant(1, "139471"));
                _context.InMemoryPlants.Add(new Plant(2, "192028"));
                _context.InMemoryPlants.Add(new Plant(2, "121062"));
                _context.InMemoryPlants.Add(new Plant(2, "104436"));
                _context.InMemoryPlants.Add(new Plant(2, "157522"));
                _context.InMemoryPlants.Add(new Plant(3, "144233"));
                _context.InMemoryPlants.Add(new Plant(3, "146173"));
                _context.InMemoryPlants.Add(new Plant(3, "149759"));
                _context.InMemoryPlants.Add(new Plant(3, "118145"));
                _context.InMemoryPlants.Add(new Plant(4, "157829"));
                _context.InMemoryPlants.Add(new Plant(4, "167013"));
                _context.InMemoryPlants.Add(new Plant(4, "171348"));
                _context.InMemoryPlants.Add(new Plant(4, "116755"));
                _context.InMemoryPlants.Add(new Plant(5, "168631"));
                _context.InMemoryPlants.Add(new Plant(5, "142627"));
                _context.InMemoryPlants.Add(new Plant(5, "111375"));
                _context.InMemoryPlants.Add(new Plant(5, "146933"));


                _context.SaveChanges();
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetInMemoryUsers()
        {
            return await _context.InMemoryUsers.Include(p=>p.Plants).ToListAsync();
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
