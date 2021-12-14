// See https://aka.ms/new-console-template for more information
/*
 * CURRENTLY ONLY A TEST FILE
 */
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;
using Console_Runner;


//acc.Password = "password";
/*string input = Console.ReadLine();
if (input == "userSignUp")
{
    um.userSignUp();
}
if (input == "userDelete")
{   
    string email = Console.ReadLine();
    um.userDelete(email);
}*/
UM um = new UM();

um.getAllUsers();
