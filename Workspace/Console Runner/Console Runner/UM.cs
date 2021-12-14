using Class1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

namespace Console_Runner
{
    public class UM
    {

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
        public bool userSignUp(Account acc)
        {
            try
            {
                using(var context = new Context())
                {
                    context.accounts.Add(acc);
                    context.SaveChanges();
                }
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }

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

        public Account readData(string targetPK)
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

        public bool updateData(string targetPK, string nEmail, string nFname, string nLname)
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
    }
    
   
}
