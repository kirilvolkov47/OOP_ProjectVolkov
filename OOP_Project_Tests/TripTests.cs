using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System;

namespace OOP_Project_Tests
{
    [TestClass]
    public class TripTests
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
        public void UpdateStatus_ValidStatus_ReturnsTrue()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var trip = driver.Trips[0];

            bool result = trip.UpdateStatus("Confirmed");

            Assert.IsTrue(result);
            Assert.AreEqual("Confirmed", trip.Status);
        }

        [TestMethod]
        public void ViewSeatRequests_ReturnsReservationList()
        {
            var driver = new Driver { MaxPassengers = 4 };
            driver.SignUp("driver@example.com", "Jane", "Smith", new DateTime(1985, 5, 5), "+38(097)-7654321", "password123");
            driver.CreateTrip("Kyiv", "Lviv", DateTime.Now.AddDays(1), new TimeSpan(10, 0, 0), 3, 500);
            var passenger = new Passenger();
            passenger.SignUp("passenger@example.com", "John", "Doe", new DateTime(1990, 1, 1), "+38(099)-1234567", "password123");
            passenger.ReservePlace(driver.Trips[0]);
            var trip = driver.Trips[0];

            var requests = trip.ViewSeatRequests();

            Assert.IsNotNull(requests);
            Assert.AreEqual(1, requests.Count);
        }
    }
}