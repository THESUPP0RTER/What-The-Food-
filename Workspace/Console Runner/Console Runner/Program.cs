// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using User;
using Class1;
using Console_Runner;

UM um = new UM();
Account acc = new Account();
acc.Email = "mattssss@gmail.com";
//acc.Password = "password";
acc.Fname = "matt";
acc.Lname = "Quinn";
um.userSignUp(acc);
um.userSignUp();