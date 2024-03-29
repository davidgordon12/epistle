﻿using EpistleLibrary.Data;
using EpistleLibrary.Models;

namespace EpistleLibrary.Services
{
    public class UserService
    {
        /// <summary>Checks if the user's login information is valid</summary>
        /// <returns>The user's username, or, if not found, an empty string</returns>
        public static string GetUser(string username, string password)
        {
            password = Hash.HashPassword(password);
            EpistleContext context = new();
            var user = context.EpistleUsers.FirstOrDefault(x => x.Username == username && x.Password == password);

            if(user is null)
            {
                return string.Empty;
            }

            return user.Username;
        }

        /// <summary>Creates the user in the database</summary>
        /// <returns>True if the user is created successfully</returns>
        public static bool CreateUser(string username, string password, string email)
        {
            try
            {
                password = Hash.HashPassword(password);
                EpistleContext context = new();
                context.Add(new UserModel
                {
                    Username = username,
                    Password = password,
                    Email = email
                });
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>Deletes the user from the database</summary>
        /// <returns>True if the user is deleted successfully</returns>
        public static bool DeleteUser()
        {
            return true;
        }
    }
}
