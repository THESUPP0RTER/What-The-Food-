﻿// See https://aka.ms/new-console-template for more information
/*
 * CURRENTLY ONLY A TEST FILE
 */
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;
using Console_Runner;


/*
 * TODO
 * bulk operations
 * atleast 1 admin at all times
 * ensure admin is the only one that can access admin stuff
 * ensure system failures dont bring down system
 */
UM um = new UM();
/*Account admin = new Account();
admin.Email = "admin";
admin.Password = "pass";
admin.accessLevel = 2;
admin.isActive = true;
admin.Fname = "matt0";
admin.Lname = "q";
um.UserSignUp(admin);*/
Console.Write("Please sign in. Email: ");
string id = Console.ReadLine();
Console.Write("\nPassword: ");
string password = Console.ReadLine();
bool loggedIn = um.AuthenticateUserPass(id, password);
Account currentUser = new Account();
if (loggedIn)
{
    currentUser = um.UserReadData(id);
}
string input = "";

while (input != "exit" && loggedIn)
{
    Console.WriteLine("Enter one of the following commands to demo functionality: \nusersignup\nUserDelete\nUserReadData\nGetAllUsers\nDisableAccount\nEnableAccount\nExit");

    Console.WriteLine("..................................................................");
    input = Console.ReadLine();
    input = input.ToLower();
    if (input == "usersignup")// Create account
    {
        um.UserSignUp();
    }
    else
    if (input == "userdelete")//Deletes an account
    {
        um.UserDelete();
    }
    else
    if (input == "userreaddata") //reads data from a specified account
    {
        um.UserReadData();
    }
    else
    if (input == "userupdatedata") //Updates data of a specified account
    {
        um.UserUpdateData();
    }
    else
    if (input == "getallusers") // prints out all user data in the database.
    {
        um.GetAllUsers();
    }
    else
    if (input == "disableaccount")
    {
        um.DisableAccount(currentUser);
    }
    else
    if (input == "enableaccounts")
    {
        um.EnableAccount(currentUser);
    }
    else
        Console.WriteLine("not valid command");
}

