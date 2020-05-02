using System;
using System.Collections.Generic;
using System.Text;

namespace WGUCapstoneProject.Models
{
    interface IUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public void Login();
    }
}
