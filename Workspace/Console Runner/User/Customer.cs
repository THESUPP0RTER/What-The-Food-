using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace User
{
    public class Customer
    {
        public Guid email { get; set; }
        public string name { get; set; }
      

    }
}
