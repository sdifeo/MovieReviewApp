using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieReviewApp.Models
{
    internal class User
    {
        //public int Id { get; set; }
        [PrimaryKey]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }
    }

}
