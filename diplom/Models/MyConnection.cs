using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diplom.Models
{
    public class MyConnection:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=USER-PC;Database=webservise;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Lot> Lots { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
