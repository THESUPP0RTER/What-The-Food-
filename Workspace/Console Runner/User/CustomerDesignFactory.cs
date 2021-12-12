using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class1;
using Microsoft.EntityFrameworkCore;

namespace Class1
{
    public class CustomerDesignFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("Customer_DesignTime_ConnectionString ");
            var MySqlServerVersion = Environment.GetEnvironmentVariable("Customer_MYSQL_Version");
            
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(MySqlServerVersion),
                options => options.MigrationsAssembly("Customers.migrations")
                );
            var Context = new Context(optionsBuilder.Options);
            return Context;
        }
    }
}
