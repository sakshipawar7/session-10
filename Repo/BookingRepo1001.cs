using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Repo
{
    public interface IBookingRepo1001
    {
        void AddBooking(List<FlightModel1001> f, BookingModel1001 booking);
        void AddBulkBookings(List<FlightModel1001> f, List<BookingModel1001> bookings);
        List<BookingModel1001> GetAllBookings();
        List<BookingModel1001> GetBookingsWithDateRange(DateTime startDate, DateTime endDate);
        decimal GetEarningsWithDateRange(DateTime startDate, DateTime endDate);
        BookingModel1001 GetBookingById(int bookingID);
        void RemoveBookingById(List<FlightModel1001> f, int bookingID);
        CustomerModel1001 GetCustomerDetailsByBookingId(List<CustomerModel1001> c ,int bookingID);
        List<FlightModel1001> GetAllFlightsWithSourceByBookingId(List<FlightModel1001> f, int bookingID);
        void AddPassengersToGivenBooking(List<FlightModel1001> f,int bookingID, int numberOfPassengers);
    }

    public class BookingRepo1001 : IBookingRepo1001
    {
        private List<BookingModel1001> _bookings;

        public BookingRepo1001()
        {
            _bookings = new List<BookingModel1001>();
        }

        public void AddBooking(List<FlightModel1001> f, BookingModel1001 booking)
        {
            foreach(FlightModel1001 f1 in f)
            {
                if(f1.FlightID == booking.FlightID)
                {
                    if(f1.MaxCapacity - f1.CurrentlyBooked >= booking.NumberOfPassengers)
                    {
                        _booking.Add(booking);
                        f1.CurrentlyBooked += booking.NumberOfPassengers;
                    }
                }
            }
        }

        public void AddBulkBookings(List<FlightModel1001> f, List<BookingModel1001> bookings)
        {
            foreach( BookingModel1001 b in bookings)
            {
                foreach(FlightModel1001 f2 in f)
                {
                    if(f2.FlightID == b.FlightID)
                    {
                       if(f2.MaxCapacity - f2.CurrentlyBooked >= b.NumberOfPassengers)
                        {
                            _booking.Add(b);
                            f2.CurrentlyBooked += b.NumberOfPassengers;
                        }
                    }
                }
            }
        }

        public List<BookingModel1001> GetAllBookings()
        {
            return _bookings;
        }

        public List<BookingModel1001> GetBookingsWithDateRange(DateTime startDate, DateTime endDate)
        {
            var bookingsInRange = new List<BookingModel1001>();
            foreach (var booking in _bookings)
            {
                if (booking.BookedOnDate >= startDate && booking.BookedOnDate <= endDate)
                {
                    bookingsInRange.Add(booking);
                }
            }
            return bookingsInRange;
        }

        public decimal GetEarningsWithDateRange(DateTime startDate, DateTime endDate)
        {
            decimal earnings = 0;
            foreach (var booking in _bookings)
            {
                if (booking.BookedOnDate >= startDate && booking.BookedOnDate <= endDate)
                {
                    earnings += booking.TotalBookingCost;
                }
            }
            return earnings;
        }

        public BookingModel1001 GetBookingById(int bookingID)
        {
            foreach (var booking in _bookings)
            {
                if (booking.BookingID == bookingID)
                {
                    return booking;
                }
            }
            return null;
        }

        public void RemoveBookingById(List<FlightModel1001> f, int bookingID)
        {
            for(int i = 0; i < _booking.Count; i++)
            {
                if (_booking[i].BookingID == bookingID)
                {
                    foreach(FlightModel1001 f2 in f)
                    {
                        if(f2.FlightID == _booking[i].FlightID)
                        {
                            f2.CurrentlyBooked -= _booking[i].NumberOfPassengers;
                            _booking.Remove(_booking[i]);                           
                        }
                    }
                }
            }
        }

        public CustomerModel1001 GetCustomerDetailsByBookingId(List<CustomerModel1001> c, int bookingID)
        {
            foreach(BookingModel1001 b in _bookings)
            {
                if(b.BookingID == bookingID)
                {
                    foreach(CustomerModel1001 c2 in c)
                    {
                        if(c2.CustomerID == b.CustomerID)
                        {
                            return c2;
                        }
                    }
                }
            }
            return null;
        }
        public List<FlightModel1001> GetAllFlightsWithSourceByBookingId(List<FlightModel1001> f, int bookingID)
        {
            List<FlightModel1001> l = new List<FlightModel1001>();
            string s = "";
            foreach(BookingModel1001 b in _booking)
            {
                if(b.BookingID == bookingID)
                {
                    foreach(FlightModel1001 f2 in f)
                    {
                        if(f2.FlightID == b.BookingID)
                            s = f2.Source;
                    }
                    foreach(FlightModel1001 f3 in f)
                    {
                        if (f3.Source.Equals(s))
                        {
                            l.Add(f3);  
                        }
                    }
                }
            }
            return l;
        }

        public void AddPassengersToGivenBooking(List<FlightModel1001> f, int bookingID, int numberOfPassengers)
        {
            foreach(BookingModel1001 b in _booking)
            {
                if(b.BookingID == bookingID)
                {
                    foreach(FlightModel1001 f2 in f)
                    {
                        if(f2.FlightID == b.FlightID)
                        {
                            if(f2.MaxCapacity - f2.CurrentlyBooked >= numberOfPassengers)
                            {
                                b.NumberOfPassengers += numberOfPassengers;
                                f2.CurrentlyBooked += numberOfPassengers;
                            }
                        }
                    }
                }
            }
        }



    }
}
