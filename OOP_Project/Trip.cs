namespace OOP_Project
{
    public class Trip
    {
        public int Id { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public bool UpdateStatus(string newStatus) => throw new NotImplementedException();
        public List<Reservation> ViewSeatRequests() => throw new NotImplementedException();
    }
}