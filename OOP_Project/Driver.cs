namespace OOP_Project
{
    public class Driver : User, ITripManagement, INotificationService, IReservationHandling
    {
        public List<Trip> Trips { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public string CarModel { get; set; }
        public int MaxPassengers { get; set; }

        public void SendNotification(string message, User recipient) => throw new NotImplementedException();
        public bool CreateTrip(string departure, string destination, DateTime date, TimeSpan time, int seats, decimal price) => throw new NotImplementedException();
        public bool EditTrip(int tripId, string newDestination) => throw new NotImplementedException();
        public bool DeleteTrip(int tripId) => throw new NotImplementedException();
        public List<Reservation> ViewRequests() => throw new NotImplementedException();

        public bool ApproveRequest(int reservationId) => throw new NotImplementedException();
        public bool DeclineRequest(int reservationId) => throw new NotImplementedException();
    }
}