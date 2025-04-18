using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;

namespace OOP_Project_Tests
{
    [TestClass]
    public class ReservationTests
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
        public void ApproveRequest_ValidReservation_ReturnsTrue()
        {
            var reservation = new Reservation { ReservationID = 1, Status = "Pending" };
            bool result = reservation.ApproveRequest(1);
            Assert.IsTrue(result);
            Assert.AreEqual("Approved", reservation.Status);
        }

        [TestMethod]
        public void DeclineRequest_ValidReservation_ReturnsTrue()
        {
            var reservation = new Reservation { ReservationID = 2, Status = "Pending" };
            bool result = reservation.DeclineRequest(2);
            Assert.IsTrue(result);
            Assert.AreEqual("Declined", reservation.Status);
        }
    }
}