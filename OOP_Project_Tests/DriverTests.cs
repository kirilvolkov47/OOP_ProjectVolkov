using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System;
using System.Collections.Generic;

namespace OOP_Project_Tests
{
    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        public void CreateTrip_ValidData_ReturnsTrue()
        {
            var driver = new Driver();
            bool result = driver.CreateTrip("Ukraine", "Germany", DateTime.Now.AddDays(1), TimeSpan.FromHours(9), 10, 1500);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EditTrip_ValidData_ReturnsTrue()
        {
            var driver = new Driver();
            driver.CreateTrip("Ukraine", "Germany", DateTime.Now.AddDays(1), TimeSpan.FromHours(9), 10, 1500);
            bool result = driver.EditTrip(1, "Italy");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteTrip_ValidTripId_ReturnsTrue()
        {
            var driver = new Driver();
            driver.CreateTrip("Ukraine", "Germany", DateTime.Now.AddDays(1), TimeSpan.FromHours(9), 10, 1500);
            bool result = driver.DeleteTrip(1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ViewRequests_ReturnsReservationsList()
        {
            var driver = new Driver();
            List<Reservation> reservations = driver.ViewRequests();
            Assert.IsNotNull(reservations);
        }
    }
}
