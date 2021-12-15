// See https://aka.ms/new-console-template for more information
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
 * ensure system failures dont bring down system
 * add new admin account
 */

Account admin = new Account();
admin.Email = "admin";
admin.Password = "pass";
admin.accessLevel = 2;
admin.isActive = true;
admin.Fname = "matt0";
admin.Lname = "q";

UM um = new UM();

um.UserSignUp(admin);

bool loggedIn = false;

while (!loggedIn)
{


    Console.Write("Please sign in. \nEmail: ");
    string id = Console.ReadLine();
    Console.Write("\nPassword: ");
    string password = Console.ReadLine();
    Account currentUser = um.signIn(id, password);

    if (currentUser != null)
    {
        loggedIn = true;
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
            um.UserDelete(currentUser);
        }
        else
        if (input == "userreaddata") //reads data from a specified account
        {
            um.UserReadData();
        }
        else
        if (input == "userupdatedata") //Updates data of a specified account
        {
            um.UserUpdateData(currentUser);
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
        if (input == "enableaccount")
        {
            um.EnableAccount(currentUser);
        }
        else
            Console.WriteLine("not valid command");

        /* checks if the current sessions email is null. This is to catch cases where user information was modified mid session 
         * checks if user permissions have changed.
         */
        if (currentUser.Email == null)
        {
            Console.WriteLine("email was null");
            loggedIn = false;
        }
        else
        if (!(um.UserReadData(currentUser.Email).isAdmin() == currentUser.isAdmin()) || !(um.UserReadData(currentUser.Email).isActive == currentUser.isActive))
        {
            Console.WriteLine((!um.UserReadData(currentUser.Email).Equals(currentUser)));
            Console.WriteLine("account object was modified");
            loggedIn = false;
        }
    }
}

