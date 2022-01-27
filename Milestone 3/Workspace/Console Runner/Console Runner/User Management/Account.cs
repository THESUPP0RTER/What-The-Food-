using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static Console_Runner.Authorization;
using System;

namespace User
{

    /*
     * Account class that will represent the contents of a user's account
     */
    //interface class
    public interface basicAccount
    {
        public string ToString();
    }

    //concrete class
    public class Account: basicAccount
    {
        //Email getter and setter
        [System.ComponentModel.DataAnnotations.Key] //set email as the PK
        public string Email { get; set; }
        //First name setter and getter
        public string Fname { get; set; }
        //Last name setter and getter
        public string Lname { get; set; }
        /*accessLevel getter and setter
         * 0 No account
         * 1 user account
         * 2 Admin account
         */
        public int accessLevel { get; set; }
        //Password getter and setter
        //[System.ComponentModel.DataAnnotations.Required]

        public Role_User role { get; set; }

        public bool isActive { get; set; }

        public string Password { get; set; }


        //TODO: I dont think we need these
        public bool isAdmin()
        {
            return this.accessLevel >= 2;

        }
        public bool isUser()
        {
            return this.accessLevel >= 1;
        }    
 
        public string ToString()
        {
            return "This is considered a base Account ";
        }

    }
    //abstract decorator
    public class accountDecorator : basicAccount //allows for users to have extra permission
    {

        private basicAccount user;
        public accountDecorator(basicAccount user)
        {
            this.user = user;
        }
        public virtual string ToString()
        {
            return this.user.ToString() + "and has a decorator ";
        }
    }

    //TODO: what exactly does each decorator do? 

    //concrete decorators
    public class accessLevelDecorator : accountDecorator
    {
        public accessLevelDecorator(basicAccount user) : base(user) { }

        public override string ToString()
        {
            return base.ToString()+"including accessLevel";
        }
    }

    //public class AMRDecorator: basicAccount
    //{
    //    private basicAccount user;
    //    public AMRDecorator(basicAccount user)
    //    {
    //        this.user = user;
    //    }

    //    public override string ToString()
    //    {
    //        return "decorated with AMR \n";
    //    }
    //}
    //public class flagDecorator: basicAccount
    //{
    //    private basicAccount user;
    //    public flagDecorator(basicAccount user)
    //    {
    //        this.user = user;
    //    }

    //    public override string ToString()
    //    {
    //        return "decorated with food flag \n";
    //    }
    //}
    //public class accountInfoDecorator : basicAccount
    //{
    //    private basicAccount user;
    //    public accountInfoDecorator(basicAccount user)
    //    {
    //        this.user = user;
    //    }

    //    public override string ToString()
    //    {
    //        return "decorated with accountInfo \n";
    //    }
    //}
  
    


}

//add-migration CreateCustomerDB
//update-database -verbose