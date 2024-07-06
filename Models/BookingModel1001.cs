using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BookingModel1001
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int FlightID { get; set; }
        public int NumberOfPassengers { get; set; }
        public DateTime BookedOnDate { get; set; }

        public decimal TotalBookingCost { get; set; }

        //public CustomerModel1001 Customer { get; set; }
        //public FlightModel1001 Flight { get; set; }

        public BookingModel1001(int bid,int cid, int fid, int numOfPass, DateTime bookedOnDate, decimal totalBookingCost)
        {
            BookingID = bid;
            CustomerID = cid;
            FlightID = fid;
            NumberOfPassengers = numOfPass;
            BookedOnDate = bookedOnDate;
            TotalBookingCost = totalBookingCost;
        }
    }
}
