using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReviewApp.Models
{
    internal class User
    {
        //public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password)
        {
            //Id = id;
            Email = email;
            Password = password;
        }

    }

}
