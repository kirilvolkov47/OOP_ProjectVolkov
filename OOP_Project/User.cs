using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOP_Project
{
    public abstract class User
    {
        private string email;
        private string name;
        private string surname;
        private DateTime birthDate;
        private string phone;
        private string password;
        private static List<string> registeredEmails = new List<string>();

        public string Email
        {
            get => email;
            set => email = !string.IsNullOrWhiteSpace(value) && value.Contains("@") ? value : throw new ArgumentException("Недійсна електронна пошта.");
        }
        public string Name
        {
            get => name;
            set => name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Ім'я не може бути порожнім.");
        }
        public string Surname
        {
            get => surname;
            set => surname = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Прізвище не може бути порожнім.");
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value > new DateTime(1900, 1, 1) ? value : throw new ArgumentException("Недійсна дата народження.");
        }
        public string Phone
        {
            get => phone;
            set => phone = Regex.IsMatch(value, @"^\+38\(0\d{2}\)-\d{7}$") ? value : throw new ArgumentException("Недійсний формат телефону.");
        }
        protected string Password
        {
            get => password;
            set => password = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Пароль не може бути порожнім.");
        }
        public bool IsSignedIn { get; private set; }

        public virtual bool SignUp(string email, string name, string surname, DateTime birthDate, string phone, string password)
        {
            if (registeredEmails.Contains(email) || string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return false;

            try
            {
                Email = email;
                Name = name;
                Surname = surname;
                BirthDate = birthDate;
                Phone = phone;
                Password = password;
                registeredEmails.Add(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(this.email) || !this.email.Equals(email, StringComparison.OrdinalIgnoreCase) || Password != password)
                return false;

            IsSignedIn = true;
            return true;
        }

        public virtual void SignOut()
        {
            IsSignedIn = false;
        }
    }
}