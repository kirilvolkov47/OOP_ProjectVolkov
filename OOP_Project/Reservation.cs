using System;

namespace OOP_Project
{
    public class Reservation : IReservationHandling
    {
        public int ReservationID { get; set; }
        public string PassengerName { get; set; }
        public Passenger Passenger { get; set; }
        public int TripID { get; set; }
        public string Status { get; set; } = "Pending";
        public int SeatsReserved { get; set; }

        public bool ApproveRequest(int reservationId)
        {
            if (ReservationID == reservationId && Status == "Pending")
            {
                Status = "Approved";
                return true;
            }
            return false;
        }

        public bool DeclineRequest(int reservationId)
        {
            if (ReservationID == reservationId && Status == "Pending")
            {
                Status = "Declined";
                return true;
            }
            return false;
        }
    }
}