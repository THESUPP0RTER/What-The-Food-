// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;

//Customer test = new Customer();
//test.name = "Matt";
//Startup letsGo = new Startup();
//IServiceCollection services = new ServiceCollection();
//letsGo.ConfigureServices(services);
using (var context = new Context())
{
    var acc = new Account()
    {
        Email = "Fake@gmail.com",
        Fname = "fake name",
        Lname = "super fake last name"
    };
    context.accounts.Add(acc);
    context.SaveChanges();
    

}