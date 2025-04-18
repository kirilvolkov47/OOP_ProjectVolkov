using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System;

namespace OOP_Project_Tests
{
    [TestClass]
    public class DriverTests
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
        public void CreateTrip_ValidData_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");

            bool result = driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);

            Assert.IsTrue(result);
            Assert.AreEqual(1, driver.Trips.Count);
        }

        [TestMethod]
        public void EditTrip_ValidData_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);

            bool result = driver.EditTrip(1, "Odessa");

            Assert.IsTrue(result);
            Assert.AreEqual("Odessa", driver.Trips[0].Destination);
        }

        [TestMethod]
        public void DeleteTrip_ValidTripId_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);

            bool result = driver.DeleteTrip(1);

            Assert.IsTrue(result);
            Assert.AreEqual(0, driver.Trips.Count);
        }

        [TestMethod]
        public void ViewRequests_ReturnsReservationsList()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");
            passenger.ReservePlace(driver.Trips[0]);

            var requests = driver.ViewRequests();

            Assert.IsNotNull(requests);
            Assert.AreEqual(1, requests.Count);
        }

        [TestMethod]
        public void ApproveRequest_ValidReservation_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");
            passenger.ReservePlace(driver.Trips[0]);

            bool result = driver.ApproveRequest(1);

            Assert.IsTrue(result);
            Assert.AreEqual("Approved", driver.Trips[0].Reservations[0].Status);
        }

        [TestMethod]
        public void DeclineRequest_ValidReservation_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");
            passenger.ReservePlace(driver.Trips[0]);

            bool result = driver.DeclineRequest(1);

            Assert.IsTrue(result);
            Assert.AreEqual("Declined", driver.Trips[0].Reservations[0].Status);
        }
    }
}