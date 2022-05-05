using Microsoft.EntityFrameworkCore;
using EpistleLibrary.Data;
using EpistleLibrary.Models;

namespace EpistleLibrary.Services
{
    public class UserService
    {
        public static string GetUser(string username, string password)
        {


            return "David";
        }

        public static bool CreateUser(string username, string password)
        {
            try
            {
                EpistleContext context = new();

                context.Add(new UserModel
                {
                    Username = username,
                    Password = password
                });

                context.SaveChanges();

                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteUser()
        {
            return true;
        }
    }
}
