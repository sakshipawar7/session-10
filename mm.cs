using Microsoft.CodeAnalysis.Operations;
using WebApplication1.Models;
using System;
namespace WebApplication1.Repo
{
    public interface IBookingRepo1001
    {
        void AddBooking(BookingModel1001 booking);
        void AddBulkBookings(List<BookingModel1001> bookings);
        List<BookingModel1001> GetAllBookings();
        List<BookingModel1001> GetBookingsWithDateRange(DateTime startDate, DateTime endDate);
        decimal GetEarningsWithDateRange(DateTime startDate, DateTime endDate);
        BookingModel1001 GetBookingById(int bookingID);
        void RemoveBookingById(int bookingID);
        CustomerModel1001 GetCustomerDetailsByBookingId(int bookingID);
        List<FlightModel1001> GetAllFlightsWithSourceByBookingId(int bookingID);
        void AddPassengersToGivenBooking(int bookingID, int numberOfPassengers);
    }
    public class BookingRepo1001 : IBookingRepo1001
    {
        private List<BookingModel1001> _booking;

        public BookingRepo1001()
        {
            _booking = new List<BookingModel1001>();
        }

        public void AddBooking(BookingModel1001 booking)
        {
            booking.BookingID = _booking.Count + 1;
            _booking.Add(booking);
        }

        public void AddBulkBookings(List<BookingModel1001> bookings)
        {
            for (int i = 0; i < bookings.Count; i++)
            {
                bookings[i].BookingID = _booking.Count + 1;
                _booking.Add(bookings[i]);
            }
        }

        public List<BookingModel1001> GetAllBookings()
        {
            return _booking;
        }

        public List<BookingModel1001> GetBookingsWithDateRange(DateTime startDate, DateTime endDate)
        {
            var bookingsInRange = new List<BookingModel1001>();
            foreach (var booking in _booking)
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
            foreach (var booking in _booking)
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
            foreach (var booking in _booking)
            {
                if (booking.BookingID == bookingID)
                {
                    return booking;
                }
            }
            return null;
        }

        public void RemoveBookingById(int bookingID)
        {
            BookingModel1001 bookingToRemove = null;
            foreach (var booking in _booking)
            {
                if (booking.BookingID == bookingID)
                {
                    bookingToRemove = booking;
                    break;
                }
            }
            if (bookingToRemove != null)
            {
                _booking.Remove(bookingToRemove);
            }
        }

        public CustomerModel1001 GetCustomerDetailsByBookingId(int bookingID)
        {
            foreach (var booking in _booking)
            {
                if (booking.BookingID == bookingID)
                {
                    return booking.Customer;
                }
            }
            return null;
        }

        public IEnumerable<FlightModel1001> GetAllFlightsWithSourceByBookingId(int bookingID)
        {
            var booking = GetBookingById(bookingID);
            if (booking == null || booking.Flight == null)
            {
                return new List<FlightModel1001>(); // Return empty list if booking not found or flight not assigned
            }

            var flightsWithSameSource = new List<FlightModel1001>();
            foreach (var flight in _flights)
            {
                if (flight.Source == booking.Flight.Source && flight.FlightID != booking.Flight.FlightID)
                {
                    flightsWithSameSource.Add(flight);
                }
            }
            return flightsWithSameSource;
        }
    }
}


