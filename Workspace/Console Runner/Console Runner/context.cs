using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

namespace Class1
{
    public class Context : DbContext
    {
        //public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;user=root;password=myPassword;Database=ef");
        }
        

        public DbSet<Customer> customers { get; set; }
        public DbSet<FoodItem> foodItems { get; set; }
    }

}
