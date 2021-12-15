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
        const string UM_CATEGORY = "Data Store";
        Logging logger;

        public UM()
        {
            Console.WriteLine("Creating UM object");
            logger = new Logging();
        }

        //User sign up will take in appropriate information from console and add new user to DB
        public bool UserSignUp()
        {
            Account acc = new Account();
            try
            {

                using (var context = new Context())
                {
                    Console.WriteLine("Enter Email");
                    acc.Email = Console.ReadLine();
                    while(context.accounts.Find(acc.Email) != null)
                    {
                        Console.WriteLine("EMAIL ALREADY IN USE Enter a different email");
                        acc.Email = Console.ReadLine();
                    }
                    if (acc == null)
                    {
                        Console.WriteLine("No such account exists");
                        return false;
                    }
                    Console.WriteLine("Enter password");
                    acc.Password = Console.ReadLine();
                    Console.WriteLine("Enter fname");
                    acc.Fname = Console.ReadLine();
                    Console.WriteLine("Enter lname");
                    acc.Lname = Console.ReadLine();
                    acc.isActive = true;
                    context.accounts.Add(acc);
                    context.SaveChanges();
                    logger.logAccountCreation(UM_CATEGORY, "test page", true, "", acc.Email);
                }
                return true;
            }catch(Exception ex)
            {
                logger.logAccountCreation(UM_CATEGORY, "test page", false, ex.Message, acc.Email);
                return false;
            }
            
        }

        //User sign up will take in appropriate information from an account object and add new user to DB
        public bool UserSignUp(Account acc)
        {
            try
            {
                using(var context = new Context())
                {
                    context.accounts.Add(acc);
                    context.SaveChanges();
                    logger.logAccountCreation(UM_CATEGORY, "test page", true, "", acc.Email);
                }
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.logAccountCreation(UM_CATEGORY, "test page", false, ex.Message, acc.Email);
                return false;
            }
            
        }
        //User sign up will take appropriate information from arguments and add new user to DB
        public bool UserSignUp(string email, string first, string last, string pass)
        {
            try
            {

                using (var context = new Context())
                {
                    var acc = new Account()
                    {
                        Email = email,
                        Fname = first,
                        Lname = last,
                        Password = pass,
                        isActive = true
                    };
                    context.accounts.Add(acc);
                    context.SaveChanges();
                    logger.logAccountCreation(UM_CATEGORY, "test page", true, "", acc.Email);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logAccountCreation(UM_CATEGORY, "test page", false, ex.Message, "");
                return false;
            }

        }

        //will delete a user from a given PK from the argument 
        public bool UserDelete(string email)
        {
            try
            {
                using (var context = new Context())
                {
                    string targetPK = email;
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                    {
                        Console.WriteLine("No such account exists");
                        return false;
                    }
                    context.Remove(acc);
                    context.SaveChanges();
                    logger.logAccountDeletion(UM_CATEGORY, "test page", true, "", email);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logAccountDeletion(UM_CATEGORY, "test page", false, ex.Message, email);
                return false;
            }
        }
        //will delete a user through console
        public bool UserDelete(Account currentUser)
        {
            if (!currentUser.isAdmin())
            {
                logger.logAccountDeletion(UM_CATEGORY, "test page", false, "ADMIN ACCESS NEEDED", currentUser.Email);
                return false;
            }
            try
            {
                using (var context = new Context())
                {
                    Console.WriteLine("Enter email address of the account desired to delete");
                    string targetPK = Console.ReadLine();
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                    {
                        return false;
                    }
                    if (acc.isAdmin() && (AdminCount() < 2))
                    {
                        Console.WriteLine("Deleting this account would result in there being no admins.");
                        return false;
                    }
                    Console.WriteLine("Deletion successful.");
                    context.Remove(acc);
                    context.SaveChanges();
                    logger.logAccountDeletion(UM_CATEGORY, "test page", true, "", currentUser.Email);
                    return true ;
                }
            }
            catch (Exception ex)
            {
                logger.logAccountDeletion(UM_CATEGORY, "test page", false, ex.Message, currentUser.Email);
                return false;
            }
        }

        //will return an account object from the DB given a PK from the argument field
        public Account UserReadData(string targetPK)
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
                logger.logGeneric(UM_CATEGORY, "test page", false, ex.Message, targetPK, "Failed to read.");
                return null;
            }
        }
        public Account UserReadData()
        {
            try
            {
                using (var context = new Context())
                {
                    Console.WriteLine("Enter email of user you wish to look up");
                    string targetPK = Console.ReadLine();
                    Account acc = context.accounts.Find(targetPK);

                    Console.WriteLine(acc.ToString());
                    return acc;
                }
            }
            catch (Exception ex)
            {
                logger.logGeneric(UM_CATEGORY, "test page", false, ex.Message, "", "Failed to read.");
                return null;
            }
        }



        //will update a user's data from a given PK in the argument, fields being changed are given in the argument line as well, null input means no change
        public bool UserUpdateData(string targetPK, string nEmail, string nFname, string nLname)
        {
            bool emailChanged = false, fNameChanged = false, lNameChanged = false;
            string eTemp = "", fTemp = "", lTemp = "";
            try
            {
                using (var context = new Context())
                {
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                        Console.WriteLine("NULL ACCOUNT FOUND");
                    if (nEmail != null) 
                    {
                        eTemp = acc.Email;
                        acc.Email = nEmail;
                        emailChanged = true;
                    }
                    if (nFname != null)
                    {
                        fTemp = acc.Fname;
                        acc.Fname = nFname;
                        fNameChanged = true;
                    }
                    if (nLname != null)
                    {
                        lTemp = acc.Lname;
                        acc.Lname = nLname;
                        lNameChanged = true;
                    }
                    context.accounts.Update(acc);
                    context.SaveChanges();

                    if(emailChanged)
                        logger.logAccountEmailChange(UM_CATEGORY, "test page", true, "", acc.Email, eTemp, acc.Email);
                    if(fNameChanged)
                        logger.logAccountNameChange(UM_CATEGORY, "test page", true, "", acc.Email, fTemp, nFname);
                    if(lNameChanged)
                        logger.logAccountNameChange(UM_CATEGORY, "test page", true, "", acc.Email, lTemp, nLname);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logGeneric(UM_CATEGORY, "test page", false, ex.Message, targetPK, "Could not change user info");
                return false;
            }
        }
        public bool UserUpdateData(Account currentUser)
        {
            bool fNameChanged = false, lNameChanged = false;
            string fTemp = "", lTemp = "";
            if (!currentUser.isAdmin())
            {
                logger.logGeneric(UM_CATEGORY, "test page", false, "ADMIN ACCESS NEEDED", currentUser.Email, "ADMIN ACCESS NEEDED TO UPDATE USER DATA");
                return false;
            }
            try
            {
                using (var context = new Context())
                {
                    Console.WriteLine("Enter email address");
                    string targetPK = Console.ReadLine();
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                    {
                        Console.WriteLine("No such account exists");
                        return false;
                    }
                    Console.WriteLine("Enter new First name or enter to skip");
                    string nFname = Console.ReadLine();
                    Console.WriteLine("Enter new Last Name or enter to skip");
                    string nLname = Console.ReadLine();
                    if (acc == null)
                        Console.WriteLine("NULL ACCOUNT FOUND");
                    if (nFname != null)
                    {
                        acc.Fname = nFname;
                        fNameChanged = true;
                    }
                    if (nLname != null)
                    {
                        acc.Lname = nLname;
                        lNameChanged=true;
                    }
                    context.accounts.Update(acc);
                    context.SaveChanges();
                    if (fNameChanged)
                        logger.logAccountNameChange(UM_CATEGORY, "test page", true, "", acc.Email, fTemp, nFname);
                    if (lNameChanged)
                        logger.logAccountNameChange(UM_CATEGORY, "test page", true, "", acc.Email, lTemp, nLname);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logGeneric(UM_CATEGORY, "test page", false, ex.Message, currentUser.Email, "Could not change user info");
                return false;
            }
        }

        //authenticates a users input password for login. True if pass matches, false otherwise
        public bool AuthenticateUserPass(string user,string userPass)
        {
            Account acc = UserReadData(user);
            return (acc != null && acc.Password == userPass);
        }
        public Account signIn(string user, string userPass)
        {
            if (AuthenticateUserPass(user, userPass))
            {
                logger.logLogin(UM_CATEGORY, "test page", true, "", user);
                return UserReadData(user);
            }
            else
            {
                logger.logLogin(UM_CATEGORY, "test page", false, "Invalid Password", user);
                return null;
            }
        }
        
        public bool GetAllUsers()
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
                logger.logGeneric(UM_CATEGORY, "test page", false, ex.Message, "No user", "Could not retrieve all users");
                return false;
            }
        }
        public bool DisableAccount(Account currentUser)
        {   if (!currentUser.isAdmin())
            {
                logger.logAccountDeactivation(UM_CATEGORY, "Console", false, "ADMIN ACCESS NEEDED", currentUser.Email, "No Target");
                return false;
            }
            try
            {
                Console.WriteLine("Enter email address");
                string targetPK = Console.ReadLine();
                using (var context = new Context())
                {
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                    {
                        Console.WriteLine("No such account exists");
                        return false;
                    }
                    if (acc.isAdmin() && (AdminCount() < 2))
                    {
                        Console.WriteLine("Disabling this account would result in there being no admins.");
                        return false;
                    }
                    acc.isActive = false;
                    context.accounts.Update(acc);
                    context.SaveChanges();
                    logger.logAccountDeactivation(UM_CATEGORY, "Console", true, "", currentUser.Email, targetPK);

                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logAccountDeactivation(UM_CATEGORY, "Console", false, ex.Message, currentUser.Email, "No Target");
                return false;
            }
        }
        public bool EnableAccount(Account currentUser)
        {
            if (!currentUser.isAdmin())
            {
                logger.logAccountEnabling(UM_CATEGORY, "Console", false, "ADMIN ACCESS NEEDED", currentUser.Email, "No Target");
                return false;
            }
            try
            {
                Console.WriteLine("Enter email address of account to reenable");
                string targetPK = Console.ReadLine();
                using (var context = new Context())
                {
                    Account acc = context.accounts.Find(targetPK);
                    if (acc == null)
                    {
                        Console.WriteLine("No such account exists");
                        return false;
                    }
                    acc.isActive = true;
                    context.accounts.Update(acc);
                    context.SaveChanges(true);
                    logger.logAccountEnabling(UM_CATEGORY, "Console", true, "", currentUser.Email, targetPK);

                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logAccountEnabling(UM_CATEGORY, "Console", false, ex.Message, currentUser.Email, "No Target");
                return false;
            }
        }
        public bool promoteToAdmin(Account currentUser)
        {
            Console.WriteLine("Enter target email");
            String targetPK = Console.ReadLine();
            try
            {
                if (currentUser.isAdmin() && currentUser.isActive)
                {
                    using (var context = new Context())
                    {
                        Account acc = context.accounts.Find(targetPK);
                        if (acc == null)
                        {
                            Console.WriteLine("No such account exists");
                            return false;
                        }
                        acc.accessLevel = 2;
                        context.Update(acc);
                        context.SaveChanges();
                        logger.logAccountPromote(UM_CATEGORY, "Console", true, "", currentUser.Email, targetPK);
                    }
                    return true;
                }
                logger.logAccountPromote(UM_CATEGORY, "Console", false, "User is not admin and/or target account is not active", currentUser.Email, targetPK);
                return false;
                
            }catch (Exception ex)
            {
                logger.logAccountPromote(UM_CATEGORY, "Console", false, ex.Message, currentUser.Email, targetPK);
                return false;
            }
        }
        public int AdminCount()
        {
            int count = 0;
            using (var context = new Context())
            {
                foreach (var account in context.accounts)
                {
                    if (account.accessLevel >= 2 && account.isActive) count++;
                }
            }
            return count;
        }
    }   
}