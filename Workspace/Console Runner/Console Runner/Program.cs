// See https://aka.ms/new-console-template for more information
using User;

Console.WriteLine("Hello, World!");
var connectionString = "Server -= (localdb); Database = myDataBase; Uid = root; Pwd = myPassword;";

Customer test = new Customer();
test.name = "Matt";
test.email = "testttt";
Startup letsGo = new Startup();
letsGo.ConfigureServices();
letsGo.save