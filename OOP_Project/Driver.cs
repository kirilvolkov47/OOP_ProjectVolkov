using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace OOP_Project
{
    public class Driver : User, ITripManagement, IReservationHandling, INotificationService
    {
        private List<Trip> trips = new List<Trip>();
        private List<Review> reviews = new List<Review>();
        private static readonly string tripsFilePath = "trips.json";
        private static List<Trip> allTrips = new List<Trip>();

        public List<Trip> Trips { get => trips; }
        public List<Review> Reviews { get => reviews; }
        public string CarModel { get; set; }
        public int MaxPassengers { get; set; }

        public delegate void NotificationHandler(string message, User recipient);
        public event NotificationHandler NotificationSent;

        public bool CreateTrip(string departure, string destination, DateTime date, TimeSpan time, int seats, decimal price)
        {
            if (string.IsNullOrWhiteSpace(departure) || string.IsNullOrWhiteSpace(destination) ||
                date < DateTime.Now || seats < 1 || seats > MaxPassengers || price <= 0)
                return false;

            var trip = new Trip
            {
                Id = allTrips.Count + 1,
                Departure = departure,
                Destination = destination,
                Date = date,
                Time = time,
                SeatsAvailable = seats,
                Price = price,
                Status = "Заплановано",
                Driver = this
            };
            trips.Add(trip);
            lock (allTrips)
            {
                allTrips.Add(trip);
                try
                {
                    SaveTrips();
                }
                catch { }
            }
            return true;
        }

        public bool EditTrip(int tripId, string newDestination)
        {
            var trip = trips.FirstOrDefault(t => t.Id == tripId);
            if (trip == null || string.IsNullOrWhiteSpace(newDestination))
                return false;

            trip.Destination = newDestination;
            lock (allTrips)
            {
                try
                {
                    SaveTrips();
                }
                catch { }
            }
            return true;
        }

        public bool DeleteTrip(int tripId)
        {
            var trip = trips.FirstOrDefault(t => t.Id == tripId);
            if (trip == null)
                return false;

            trips.Remove(trip);
            lock (allTrips)
            {
                allTrips.Remove(trip);
                try
                {
                    SaveTrips();
                }
                catch { }
            }
            return true;
        }

        public List<Reservation> ViewRequests()
        {
            return trips.SelectMany(t => t.Reservations).ToList();
        }

        public bool ApproveRequest(int reservationId)
        {
            var reservation = trips.SelectMany(t => t.Reservations).FirstOrDefault(r => r.ReservationID == reservationId);
            if (reservation == null || reservation.Status != "Pending")
                return false;

            var trip = trips.FirstOrDefault(t => t.Reservations.Contains(reservation));
            if (trip == null || trip.SeatsAvailable < reservation.SeatsReserved)
                return false;

            reservation.ApproveRequest(reservationId);
            trip.SeatsAvailable -= reservation.SeatsReserved;
            NotificationSent?.Invoke($"Бронювання {reservationId} підтверджено.", reservation.Passenger);
            lock (allTrips)
            {
                try
                {
                    SaveTrips();
                }
                catch { }
            }
            return true;
        }

        public bool DeclineRequest(int reservationId)
        {
            var reservation = trips.SelectMany(t => t.Reservations).FirstOrDefault(r => r.ReservationID == reservationId);
            if (reservation == null || reservation.Status != "Pending")
                return false;

            reservation.DeclineRequest(reservationId);
            NotificationSent?.Invoke($"Бронювання {reservationId} відхилено.", reservation.Passenger);
            lock (allTrips)
            {
                try
                {
                    SaveTrips();
                }
                catch { }
            }
            return true;
        }

        public void SendNotification(string message, User recipient)
        {
            NotificationSent?.Invoke(message, recipient);
        }

        private void SaveTrips()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };
            var json = JsonSerializer.Serialize(allTrips, options);
            File.WriteAllText(tripsFilePath, json);
        }

        public static List<Trip> LoadTrips()
        {
            lock (allTrips)
            {
                return new List<Trip>(allTrips);
            }
        }
    }
}