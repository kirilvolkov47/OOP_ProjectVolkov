using System;
using System.Collections.Generic;

namespace OOP_Project
{
    public class Trip
    {
        public int Id { get; set; }
        public string Departure { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Driver Driver { get; set; }
        public List<Reservation> Reservations { get; set; } = new();

        public Trip()
        {
            Reservations = new List<Reservation>();
        }

        public bool UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus)) return false;

            Status = newStatus;
            return true;
        }
        public List<Reservation> ViewSeatRequests()
        {
            return Reservations;
        }
    }
}
