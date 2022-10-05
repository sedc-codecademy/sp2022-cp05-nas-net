using NewsAggregator.InterfaceModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public User() { }
        public User(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
        }

        public void Update(UpdateUserDto model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Username = model.Username;
            Email = model.Email;
        }

        public void ChangePassword(string hashedPassword)
        {
            Password = hashedPassword;
        }
    }
}
