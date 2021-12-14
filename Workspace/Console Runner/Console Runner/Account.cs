﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace User
{
    /*
     * Account class that will represent the contents of a user's account
     */
    public class Account
    {
        //Email getter and setter
        [System.ComponentModel.DataAnnotations.Key] //set email as the PK
        public string Email { get; set; }
        //First name setter and getter
        public string Fname { get; set; }
        //Last name setter and getter
        public string Lname { get; set; }
        //accessLevel getter and setter
        public int accessLevel { get; set; }
        //Password getter and setter
        //[System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }

        public string ToString()
        {
            int pass = this.Password.Length;
            string stars = "";
            for(int i = 0; i < pass; i++)
            {
                stars += "*";
            }
            return this.Email + " " + this.Fname + " " + this.Lname + " " + stars;
        }

    }
}

//add-migration CreateCustomerDB
//update-database -verbose