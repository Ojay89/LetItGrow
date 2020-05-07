using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetItGrowInMemoryDB;
using Microsoft.EntityFrameworkCore;

namespace LetItGrowInMemoryDB.model
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext>options) : base(options)
        {

        }
        public DbSet<User> InMemoryUsers { get; set; }
    }
}
