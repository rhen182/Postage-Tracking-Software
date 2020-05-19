using System.Windows;

namespace WGUCapstoneProject.Models
{
    interface IUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CanLogin(string username, string password);
        public void Login(bool canLogin, Window loginWindow);
    }
}
