// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;
using Console_Runner;

//Customer test = new Customer();
//test.name = "Matt";
//Startup letsGo = new Startup();
//IServiceCollection services = new ServiceCollection();
//letsGo.ConfigureServices(services);
/*using (var context = new Context())
{
    var acc = new Account()
    {
        Email = "Fake@gmail.com",
        Fname = "fake name",
        Lname = "super fake last name"
    };
    context.accounts.Add(acc);
    context.SaveChanges();
    

}*/

UM um = new UM();
//um.userSignUp();
um.userDelete();




