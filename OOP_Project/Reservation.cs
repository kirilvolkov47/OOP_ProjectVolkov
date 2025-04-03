namespace OOP_Project
{
    public class Reservation : IReservationHandling
    {
        public int ReservationID { get; set; }
        public string PassengerName { get; set; }
        public int TripID { get; set; }
        public string Status { get; set; } = "Pending";
        public int SeatsReserved { get; set; }

        public bool ApproveRequest(int reservationId) => throw new NotImplementedException();
        public bool DeclineRequest(int reservationId) => throw new NotImplementedException();
    }
}