using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace User
{
    public class Customer
    {
        public string name { get; set; }
        public string email { get; set; }

    }
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Replace with your connection string.
        var connectionString = "server=localhost;user=root;password=myPassword;database=ef";

        // Replace with your server version and type.
        // Use 'MariaDbServerVersion' for MariaDB.
        // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
        // For common usages, see pull request #1233.
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        // Replace 'YourDbContext' with the name of your own DbContext derived class.
        services.AddDbContext<DbContext>(
             dbContextOptions => dbContextOptions
                 .UseMySql(connectionString, serverVersion)
                 // The following three options help with debugging, but should
                 // be changed or removed for production.
                 .LogTo(Console.WriteLine, LogLevel.Information)
                 .EnableSensitiveDataLogging()
                 .EnableDetailedErrors()
         );
    }
}