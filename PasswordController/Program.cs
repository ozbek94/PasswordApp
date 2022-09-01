using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordController
{
    public class Program
    {
        static void Main(string[] args)
        {
            string password = string.Empty;

            while (password != "-1")
            {
                Console.Write("Enter Password : ");
                password = Console.ReadLine();
                PasswordCheckMethod(password);
            }

        }

        private static bool PasswordCheckMethod(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Wrong input");
                return false;

            }
            if (!password.All(char.IsNumber))
            {
                Console.WriteLine("IsNotNumber");
                return false;
            }

            if (password.Length < 4 || password.Length > 8)
            {
                Console.WriteLine("Password must be min 4, max 8 characters.");
                return false;
            }

            var passwordChars = password.ToCharArray(); // 8 karakter 41789
            int distinctChars = passwordChars.Distinct().Count();

            if (distinctChars < 3)
            {
                Console.WriteLine("Enter minimum 3 different character.");
                return false;
            }
            var additionCheckResult = Addition(passwordChars);
            return additionCheckResult;
        }

        public static bool Addition(char[] passwordChars)
        {
            for (int i = 0; i < passwordChars.Length - 2; i++)
            {
                int addition = passwordChars[i + 1] - passwordChars[i];
                int additioncheck = passwordChars[i + 2] - passwordChars[i + 1];
                if (Math.Abs(addition) == 1 && addition == additioncheck)
                {
                    Console.WriteLine("You cannot enter consecutive numbers.");
                    return false;
                }
            }
            Console.WriteLine("Login successfully");
            return true;
        }
    }
}
