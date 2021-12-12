using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.DependencyInjection;

namespace Class1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<Context>();
    }
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; user = root; password = *RootPass*; Database = ef", 
                new MySqlServerVersion(new Version(8, 0, 27)));
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<FoodItem> foodItems { get; set; }
    }

}
