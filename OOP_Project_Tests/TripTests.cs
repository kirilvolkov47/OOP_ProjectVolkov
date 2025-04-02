using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System;
using System.Collections.Generic;

namespace OOP_Project_Tests
{
    [TestClass]
    public class TripTests
    {
        [TestMethod]
        public void UpdateStatus_ValidStatus_ReturnsTrue()
        {
            var trip = new Trip();
            bool result = trip.UpdateStatus("Active");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ViewSeatRequests_ReturnsReservationList()
        {
            var trip = new Trip();
            List<Reservation> requests = trip.ViewSeatRequests();
            Assert.IsNotNull(requests);
        }
    }
}
