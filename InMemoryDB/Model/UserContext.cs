using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMemoryDB.Model;
using Microsoft.EntityFrameworkCore;

namespace InMemoryDB.Model
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext>options) : base(options)
        {

        }
        public DbSet<User> InMemoryUsers { get; set; }
    }
}
