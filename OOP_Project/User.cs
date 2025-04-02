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

        public virtual bool SignUp(string email, string name, string surname, string password)
        {
            throw new NotImplementedException();
        }

        public virtual bool SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public virtual void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}