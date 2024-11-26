using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UserPaswordAndLoginGit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            UserProfile user = new UserProfile();

            Console.WriteLine("Username : ");
            user.Username=Console.ReadLine();
            Console.WriteLine("Password : ");
            user.Password=Console.ReadLine();

            try
            {
                userService.ValidateUser(user);
                Console.Clear();
                Console.WriteLine("Welcom to system");
            }
            catch (InvalidUserCredentialsException ex)
            {
                Console.Clear();
                Logger.LogErr(InvalidUserCredentialsException.Code, ex.Message);
            }
            finally
            {
                Console.WriteLine("Session Finished ");
            }
            Console.ReadLine();
        }
    }
    public class InvalidUserCredentialsException : Exception
    {
        public const string Code = "invalid_user_credentials";
        public InvalidUserCredentialsException()
            : base("Username or password is incorrect.")
        { }
    }
    public class Logger
    {
        public static void LogErr(string code, string message)
        {
            string logMessage = $"[ {DateTime.Now} ERR] {code}: {message}  ";
            Console.WriteLine(logMessage);
        }
    }
    public class UserService
    {
        public void ValidateUser(UserProfile user)
        {
            string validUsername = "admin";
            string validPassword = "ad123";
            if (user.Username != validUsername || user.Password != validPassword)
            {
                throw new InvalidUserCredentialsException();
            }
        }
    }
    public class UserProfile 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
