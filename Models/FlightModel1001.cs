using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class FlightModel1001
    {
        public int FlightID { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public DateTime DateOfJourney { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentlyBooked { get; set; }

        public decimal TicketCost { get; set; }

        // Navigation property for bookings
        //public ICollection<BookingModel1001> Bookings { get; set; }

        public FlightModel1001(int fId, string src, string dest, DateTime doj, DateTime depTime, DateTime arriTime, int maxCap, int currBooked, decimal tickCost)
        {
            FlightID = fId; 
            Source = src;
            Destination = dest;
            DateOfJourney = depTime;
            DepartureTime = arriTime;
            ArrivalTime = arriTime;
            MaxCapacity = maxCap;
            CurrentlyBooked = currBooked;
            TicketCost = tickCost;
        }
    }
}
