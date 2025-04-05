using System;
using System.Text.RegularExpressions;

namespace OOP_Project
{
    public abstract class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsSignedIn { get; set; }

        private static List<string> registeredEmails = new();

        public virtual bool SignUp(string email, string name, string surname, string password)
        {
            if (!email.Contains("@") || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(password))
                return false;

            Email = email;
            Name = name;
            Surname = surname;
            Password = password;
            return true;
        }



        public virtual bool SignIn(string email, string password)
        {
            if (string.Equals(Email, email, StringComparison.OrdinalIgnoreCase) && Password == password)
            {
                IsSignedIn = true;
                return true;
            }
            return false;
        }

        public virtual void SignOut()
        {
            IsSignedIn = false;
        }
    }
}
