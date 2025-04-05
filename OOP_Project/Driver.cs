using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Project
{
    public class Driver : User, ITripManagement, INotificationService, IReservationHandling
    {
        public List<Trip> Trips { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public string CarModel { get; set; }
        public int MaxPassengers { get; set; }

        public bool CreateTrip(string departure, string destination, DateTime date, TimeSpan time, int seats, decimal price)
        {
            if (string.IsNullOrWhiteSpace(departure) || string.IsNullOrWhiteSpace(destination) ||
                date < DateTime.Now || seats < 1 || price <= 0)
                return false;

            Trips.Add(new Trip
            {
                Id = Trips.Count + 1,
                Departure = departure,
                Destination = destination,
                Date = date,
                Time = time,
                SeatsAvailable = seats,
                Price = price,
                Status = "Заплановано",
                Driver = this
            });

            return true;
        }


        public bool EditTrip(int tripId, string newDestination)
        {
            var trip = Trips.FirstOrDefault(t => t.Id == tripId);
            if (trip == null || string.IsNullOrWhiteSpace(newDestination)) return false;

            trip.Destination = newDestination;
            return true;
        }

        public bool DeleteTrip(int tripId)
        {
            var trip = Trips.FirstOrDefault(t => t.Id == tripId);
            return trip != null && Trips.Remove(trip);
        }

        public List<Reservation> ViewRequests()
        {
            return Trips.SelectMany(t => t.Reservations).ToList();
        }

        public void SendNotification(string message, User recipient) { }

        public bool ApproveRequest(int reservationId)
        {
            var reservation = Trips.SelectMany(t => t.Reservations).FirstOrDefault(r => r.ReservationID == reservationId);
            if (reservation == null || reservation.Status != "Pending") return false;

            reservation.Status = "Approved";
            return true;
        }

        public bool DeclineRequest(int reservationId)
        {
            var reservation = Trips.SelectMany(t => t.Reservations).FirstOrDefault(r => r.ReservationID == reservationId);
            if (reservation == null || reservation.Status != "Pending") return false;

            reservation.Status = "Declined";
            return true;
        }

    }
}
