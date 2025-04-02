using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;

namespace OOP_Project_Tests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void ApproveRequest_ValidReservation_ReturnsTrue()
        {
            var reservation = new Reservation();
            bool result = reservation.ApproveRequest(1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeclineRequest_ValidReservation_ReturnsTrue()
        {
            var reservation = new Reservation();
            bool result = reservation.DeclineRequest(1);
            Assert.IsTrue(result);
        }
    }
}
