using Class1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

namespace Console_Runner
{
    //Current user management class
    public class UM
    {
        //User sign up will take in appropriate information from console and add new user to DB
        public bool userSignUp()
        {
            try
            {

                using (var context = new Context())
                {
                    
                    Account acc = new Account();
                    Console.WriteLine("Enter Email");
                    acc.Email = Console.ReadLine();
                    Console.WriteLine("Enter password");
                   // acc.Password = Console.ReadLine();
                    Console.WriteLine("Enter fname");
                    acc.Fname = Console.ReadLine();
                    Console.WriteLine("Enter lname");
                    acc.Lname = Console.ReadLine();

                    context.accounts.Add(acc);
                    context.SaveChanges();
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }

        //User sign up will take in appropriate information from an account object and add new user to DB
        public bool userSignUp(Account acc)
        {
            try
            {
                using(var context = new Context())
                {
                    context.accounts.Add(acc);
                    context.SaveChanges();
                    Console.WriteLine("userSignUp(acc) WORKED!!");
                }
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("ERROR IN userSignUp(acc)");
                return false;
            }
            
        }
        //User sign up will take appropriate information from arguments and add new user to DB
        public bool userSignUp(string email, string first, string last)
        {
            try
            {

                using (var context = new Context())
                {
                    var acc = new Account()
                    {
                        Email = email,
                        Fname = first,
                        Lname = last
                    };
                    context.accounts.Add(acc);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //will delete a user from a given PK from the command line
        public bool userDelete()
        {
            try
            {
                using (var context = new Context())
                {
                    Console.WriteLine("Enter email of account to be deleted");
                    string targetPK = Console.ReadLine();
                    Account acc = context.accounts.Find(targetPK);
                    context.Remove(acc);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //will delete a user from a given PK from the argument 
        public bool userDelete(string email)
        {
            try
            {
                using (var context = new Context())
                {
                    string targetPK = email;
                    Account acc = context.accounts.Find(targetPK);
                    context.Remove(acc);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //will return an account object from the DB given a PK from the argument field
        public Account userReadData(string targetPK)
        {
            try
            {
                using (var context = new Context())
                {
                    Account acc = context.accounts.Find(targetPK);
                    return acc;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //will update a user's data from a given PK in the argument, fields being changed are given in the argument line as well, null input means no change
        public bool userUpdateData(string targetPK, string nEmail, string nFname, string nLname)
        {
            try
            {
                using (var context = new Context())
                {
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                        Console.WriteLine("NULL ACCOUNT FOUND");
                    if (nEmail != null)
                        acc.Email = nEmail;
                    if (nFname != null)
                        acc.Fname = nFname;
                    if (nLname != null) 
                        acc.Lname = nLname;
                    context.accounts.Update(acc);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //authenticates a users input password for login. True if pass matches, false otherwise
        public bool authenticateUserPass(string user,string userPass)
        {
            Account acc = userReadData(user);

            if (acc.Password == userPass)
                return true;
            else
                return false;
        }

        //validates that a user account is an admin, True if admin, else false
        public bool ValidateAdmin(Account acc)
        {
            if (acc.accessLevel == 2)
                return true;
            else
                return false;
        }

        //validates that a user account is an admin, True if admin, else false
        public bool validateAdmin(string user)
        {
            Account acc = userReadData(user);
            if (acc.accessLevel == 2)
                return true;
            else
                return false;
        }

        //validates that the user is a valid account, if it is an account return true else false
        public bool ValidateUser(Account acc)
        {
            if (acc.accessLevel > 0)
                return true;
            else
                return false;
        }
        
        public bool getAllUsers()
        {
            try
            {
                using (var context = new Context())
                {
                    foreach (var account in context.accounts)
                    {
                        Console.WriteLine(account.ToString());
                    }
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }   
}