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
//um.userDelete();

string[] emails = new string[100];
string[] firsts = new string[100];
string[] lasts = new string[100];
string[] uNames = new string[100];
double cTotal = 0;
double rTotal = 0;
double uTotal = 0;
double dTotal = 0;

for (int i = 0; i < emails.Length; i++)
{
    emails[i] = i.ToString() + "@gmail.com";
    firsts[i] = "F" + i.ToString();
    lasts[i] = "L" + i.ToString();
    uNames[i] = "U" + i.ToString();
}

var watch = new System.Diagnostics.Stopwatch();
for (int j = 0; j < 11; j++)
{
    watch.Start();
    for (int i = 0; i < 10; i++)
    {
        um.userSignUp(emails[i], firsts[i], lasts[i]);
    }
    watch.Stop();
    Console.WriteLine($"----Time to create 100 users: {watch.ElapsedMilliseconds } ms");
    cTotal += watch.ElapsedMilliseconds;
    watch.Restart();

    watch.Start();
    for (int i = 0; i < 10; i++)
    {
        Account readData = um.readData(emails[i]);
    }
    watch.Stop();
    Console.WriteLine($"Time to read 100 users: {watch.ElapsedMilliseconds } ms");
    rTotal += watch.ElapsedMilliseconds;
    watch.Restart();

    watch.Start();
    for (int i = 0; i < 10; i++)
    {
        um.updateData(emails[i], null, uNames[i], null);
    }
    watch.Stop();
    Console.WriteLine($"Time to update 100 users: {watch.ElapsedMilliseconds } ms");
    uTotal += watch.ElapsedMilliseconds;
    watch.Restart();

    watch.Start();
    for (int i = 0; i < 10; i++)
    {
        um.userDelete(emails[i]);
    }
    watch.Stop();
    Console.WriteLine($"Time to delete 100 users: {watch.ElapsedMilliseconds } ms");
    dTotal += watch.ElapsedMilliseconds;
    watch.Restart();
}

Console.WriteLine($"Avg Time to create 100 users: {cTotal / 10} ms");
Console.WriteLine($"Avg Time to read 100 users: {rTotal / 10} ms");
Console.WriteLine($"Avg Time to update 100 users: {uTotal / 10} ms");
Console.WriteLine($"Avg Time to delete 100 users: {dTotal / 10} ms");
