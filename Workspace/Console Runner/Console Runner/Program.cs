// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;
using Console_Runner;

UM um = new UM();
Account acc = new Account();
acc.Email = "mattssss@gmail.com";
//acc.Password = "password";
string input = Console.ReadLine();
if (input == "userSignUp")
{
    um.userSignUp();
}
if (input == "userDelete")
{   
    string email = Console.ReadLine();
    um.userDelete(email);
}
acc.Fname = "matt";
acc.Lname = "Quinn";
um.userSignUp(acc);
