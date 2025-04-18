using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Project
{
    public class Passenger : User, INotificationService
    {
        private List<Reservation> reservations = new List<Reservation>();
        private List<Review> reviews = new List<Review>();

        public List<Reservation> Reservations { get => reservations; }
        public List<Review> Reviews { get => reviews; }

        public delegate void NotificationHandler(string message, User recipient);
        public event NotificationHandler NotificationSent;

        public List<Trip> SearchTrips(string departure, string destination)
        {
            var allTrips = Driver.LoadTrips();
            return allTrips.Where(t => t.Departure.Contains(departure, StringComparison.OrdinalIgnoreCase) &&
                                      t.Destination.Contains(destination, StringComparison.OrdinalIgnoreCase) &&
                                      t.Date >= DateTime.Now).ToList();
        }

        public bool ReservePlace(Trip trip)
        {
            if (trip == null || trip.SeatsAvailable < 1 || reservations.Any(r => r.TripID == trip.Id))
                return false;

            var reservation = new Reservation
            {
                ReservationID = reservations.Count + 1,
                Passenger = this,
                PassengerName = Name,
                TripID = trip.Id,
                Status = "Pending",
                SeatsReserved = 1
            };
            reservations.Add(reservation);
            trip.Reservations.Add(reservation);
            trip.SeatsAvailable--;
            NotificationSent?.Invoke($"Запит на бронювання для поїздки {trip.Id} надіслано.", trip.Driver);
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
            reviews.Add(review);
            trip.Driver.Reviews.Add(review);
            return true;
        }

        public void SendNotification(string message, User recipient)
        {
            NotificationSent?.Invoke(message, recipient);
        }
    }
}