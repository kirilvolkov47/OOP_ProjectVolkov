using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System;

namespace OOP_Project_Tests
{
    [TestClass]
    public class PassengerTests
    {
        [TestInitialize]
        public void Setup()
        {
            var fieldInfo = typeof(Driver).GetField("allTrips", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(null, new List<Trip>());
            }
            var userFieldInfo = typeof(User).GetField("registeredEmails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (userFieldInfo != null)
            {
                userFieldInfo.SetValue(null, new List<string>());
            }
        }

        [TestMethod]
        public void SearchTrips_ValidCriteria_ReturnsTripsList()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");

            var trips = passenger.SearchTrips("Kyiv", "Lviv");

            Assert.IsTrue(trips.Count > 0);
        }

        [TestMethod]
        public void ReservePlace_ValidTrip_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");

            bool result = passenger.ReservePlace(driver.Trips[0]);

            Assert.IsTrue(result);
            Assert.AreEqual(1, passenger.Reservations.Count);
        }

        [TestMethod]
        public void ViewDriverProfile_ValidDriver_ReturnsProfile()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");

            var profile = passenger.ViewDriverProfile(driver);

            Assert.IsNotNull(profile);
            Assert.AreEqual(driver, profile);
        }

        [TestMethod]
        public void AddReview_ValidData_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");

            bool result = passenger.AddReview(driver.Trips[0], 5, "Great trip!");

            Assert.IsTrue(result);
            Assert.AreEqual(1, passenger.Reviews.Count);
        }
    }
}