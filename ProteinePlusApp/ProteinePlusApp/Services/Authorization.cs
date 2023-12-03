using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProteinePlusApp.MVVM.Models;
using System;
using System.Linq;

namespace ProteinePlusApp.Services
{
    public class AuthService
    {
        private readonly LoginDbContext _dbContext;

        public bool IsUserAuthenticated { get; private set; }

        public void SetAuthentication(bool isAuthenticated)
        {
            IsUserAuthenticated = isAuthenticated;

            if (isAuthenticated)
            {
                Xamarin.Essentials.SecureStorage.SetAsync("IsAuthenticated", "true");
            }
            else
            {
                Xamarin.Essentials.SecureStorage.Remove("IsAuthenticated");
            }
        }

        public AuthService(LoginDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated(); // Create the database if it doesn't exist
        }

        //validating that the users login and password is correct
        public string Login(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                return "Login successful";
            }

            return "Invalid username or password";
        }

        //validating that the user doesnt already exist when signing up
        public string Signup(string username, string password)
        {
            if (_dbContext.Users.Any(u => u.Username == username))
            {
                return "Username already exists";
            }

            _dbContext.Users.Add(new Users { Username = username, Password = password });
            _dbContext.SaveChanges();

            return "Signup successful";
        }

        //password reset function
        public string ResetPassword(string username, string newPassword)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                user.Password = newPassword;
                _dbContext.SaveChanges();
                return "Password reset successful";
            }

            return "User not found";
        }

        //changes the password
        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == currentPassword);

            if (user != null)
            {
                user.Password = newPassword;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        //checking if the user exists
        public bool UserExists(string username)
        {
            return _dbContext.Users.Any(u => u.Username == username);
        }

        //logging the user out
        public void Logout()
        {
            Xamarin.Essentials.SecureStorage.Remove("AuthToken");
            Xamarin.Essentials.SecureStorage.Remove("IsAuthenticated");
        }

        public int GetUserId(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            return user?.Id ?? 0; // Return 0 if user not found, adjust this logic based on your requirements
        }
    }
}
