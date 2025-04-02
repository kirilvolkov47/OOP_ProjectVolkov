namespace OOP_Project
{
    public interface ITripManagement
    {
        bool CreateTrip(string departure, string destination, DateTime date, TimeSpan time, int seats, decimal price);
        bool EditTrip(int tripId, string newDestination);
        bool DeleteTrip(int tripId);
    }
}