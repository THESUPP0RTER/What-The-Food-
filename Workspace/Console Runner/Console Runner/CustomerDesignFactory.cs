using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Class1
{


    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Replace with your connection string.
            var connectionString = "server=localhost;user=root;password=myPassword;Database=ef";

            
            var serverVersion = new MariaDbServerVersion(ServerVersion.AutoDetect(connectionString));
            services.AddDbContext<Context>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
            );
            Console.WriteLine(serverVersion);
        }
        public void saveCustomer(User.Customer cust)
        {

        }
    }
}