using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace User
{
    public class Account
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Email { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }

        public int accessLevel { get; set; }
      

    }
}
