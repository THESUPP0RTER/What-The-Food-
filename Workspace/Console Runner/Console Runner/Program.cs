// See https://aka.ms/new-console-template for more information
/*
 * CURRENTLY ONLY A TEST FILE
 */
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;
using Console_Runner;

UM um = new UM();

string input = Console.ReadLine();
if (input == "userSignUp")// Create account
{
    um.userSignUp();
}
if (input == "userDelete")//Deletes an account
{
    um.userDelete();
}
if (input == "UserReadData") //reads data from a specified account
{
    um.userReadData();
}
if (input == "userUpdateData") //Updates data of a specified account
{
    um.userUpdateData();
}
if (input == "getAllUsers") // prints out all user data in the database.
{
    um.getAllUsers();
}
if (input == "DisableAccount")
{

}


um.getAllUsers();
