using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System;

namespace OOP_Project_Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod] public void SignUp_ValidData_ReturnsTrue() 
        { 
            var user = new Driver(); 
            bool result = user.SignUp("my@example.com", "Anton", "Pavlenko", new DateTime(1990, 1, 1), "+38(099)-1234567", "password12"); 
            Assert.IsTrue(result); 
        }

        [TestMethod]
        public void SignUp_InvalidEmail_ReturnsFalse()
        {
            var user = new Driver();
            bool result = user.SignUp("invalid_email", "Anton", "Pavlenko", new DateTime(1990, 1, 1), "+38(099)-1234567", "password12");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SignIn_ValidCredentials_ReturnsTrue()
        {
            var passenger = new Passenger();
            string email = "test@example.com";
            string password = "password123";
            passenger.SignUp(email, "Viktor", "Kanovalow", new DateTime(1990, 1, 1), "+38(099)-1234567", password);

            bool result = passenger.SignIn(email, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SignIn_InvalidCredentials_ReturnsFalse()
        {
            var user = new Driver();
            bool result = user.SignIn("my@example.com", "wrong_password");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SignOut_AfterSignIn_SetsIsSignedInToFalse()
        {
            var user = new Driver();
            user.SignUp("my@example.com", "Anton", "Pavlenko", new DateTime(1990, 1, 1), "+38(099)-1234567", "password12");
            user.SignIn("my@example.com", "password12");
            user.SignOut();
            Assert.IsFalse(user.IsSignedIn);
        }
    }

}