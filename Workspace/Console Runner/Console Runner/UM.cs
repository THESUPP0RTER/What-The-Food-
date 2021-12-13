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
                    var acc = new Account()
                    {
                        Email = Console.ReadLine(),
                        Fname = Console.ReadLine(),
                        Lname = Console.ReadLine()
                    };
                    context.accounts.Add(acc);
                    context.SaveChanges();


                }



                return true;
            }catch(Exception ex)
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
    }
    
   
}
