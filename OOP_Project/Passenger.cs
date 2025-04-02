namespace OOP_Project
{
    public class Passenger : User, INotificationService
    {
        public List<Reservation> Reservations { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();

        public List<Trip> SearchTrips(string departure, string destination) => throw new NotImplementedException();
        public bool ReservePlace(Trip trip) => throw new NotImplementedException();
        public Driver ViewDriverProfile(Driver driver) => throw new NotImplementedException();
        public bool AddReview(Trip trip, int rating, string comment) => throw new NotImplementedException();
        public void SendNotification(string message, User recipient) => throw new NotImplementedException();
    }
}