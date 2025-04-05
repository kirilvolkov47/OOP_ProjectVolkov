using System;
using System.Collections.Generic;

namespace OOP_Project
{
    public class Passenger : User, INotificationService
    {
        public List<Reservation> Reservations { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();

        public List<Trip> SearchTrips(string departure, string destination)
        {
            return new List<Trip>();
        }

        public bool ReservePlace(Trip trip)
        {
            if (trip == null || trip.SeatsAvailable < 1) return false;
            if (Reservations.Any(r => r.TripID == trip.Id)) return false;

            var reservation = new Reservation
            {
                ReservationID = Reservations.Count + 1,
                PassengerName = Name,
                TripID = trip.Id,
                Status = "Pending",
                SeatsReserved = 1
            };

            Reservations.Add(reservation);
            trip.Reservations.Add(reservation);
            trip.SeatsAvailable = Math.Max(0, trip.SeatsAvailable - 1);

            return true;
        }


        public Driver ViewDriverProfile(Driver driver)
        {
            return driver;
        }

        public bool AddReview(Trip trip, int rating, string comment)
        {
            if (trip == null || rating < 1 || rating > 5 || string.IsNullOrWhiteSpace(comment))
                return false;

            var review = new Review(this, rating, comment);
            Reviews.Add(review);
            trip.Driver.Reviews.Add(review);
            return true;
        }

        public void SendNotification(string message, User recipient) { }
    }
}
