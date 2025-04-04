﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;
using System.Collections.Generic;

namespace OOP_Project_Tests
{
    [TestClass]
    public class PassengerTests
    {
        [TestMethod]
        public void SearchTrips_ValidCriteria_ReturnsTripsList()
        {
            var passenger = new Passenger();
            List<Trip> trips = passenger.SearchTrips("Ukraine", "England");
            Assert.IsNotNull(trips);
        }

        [TestMethod]
        public void ReservePlace_ValidTrip_ReturnsTrue()
        {
            var passenger = new Passenger { Name = "Anton Pavlenko" };
            var trip = new Trip { Id = 1, Departure = "City A", Destination = "City B", SeatsAvailable = 3 };

            bool result = passenger.ReservePlace(trip);

            Assert.IsTrue(result);
            Assert.AreEqual(2, trip.SeatsAvailable);
            Assert.AreEqual(1, passenger.Reservations.Count);
        }


        [TestMethod]
        public void ViewDriverProfile_ValidDriver_ReturnsProfile()
        {
            var passenger = new Passenger();
            var driver = new Driver();
            Driver profile = passenger.ViewDriverProfile(driver);
            Assert.IsNotNull(profile);
        }

        [TestMethod]
        public void AddReview_ValidData_ReturnsTrue()
        {
            var passenger = new Passenger();
            var driver = new Driver();
            var trip = new Trip { Driver = driver };

            bool result = passenger.AddReview(trip, 5, "Amazing trip!!!");

            Assert.IsTrue(result);
        }

    }
}
