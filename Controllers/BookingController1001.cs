using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo;
using Microsoft.AspNetCore.JsonPatch;

namespace WebApplication1.Controllers
{
    [Route("Booking")]
    [ApiController]
    public class BookingController1001 : ControllerBase
    {
        private readonly IFlightRepo1001 _flightRepo;
        private readonly ICustomerRepo1001 _customerRepo;
        private readonly IBookingRepo1001 _bookingRepo;

        public BookingController1001(IFlightRepo1001 flightRepo, ICustomerRepo1001 customerRepo, IBookingRepo1001 bookingRepo)
        {
            _flightRepo = flightRepo;
            _customerRepo = customerRepo;
            _bookingRepo = bookingRepo;
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking(List<FlightModel1001> f, BookingModel1001 booking)
        {
            _bookingRepo.AddBooking(booking);
            return Ok("Success");
        }

        [HttpPost("AddBulkBookings")]
        public IActionResult AddBulkBookings(List<FlightModel1001> f, List<BookingModel1001> bookings)
        {
            _bookingRepo.AddBulkBookings(bookings);
            return Ok("Success");
        }

        [HttpGet("GetAllBookings")]
        public IActionResult GetAllBookings()
        {
            List<BookingModel1001> b = _bookingRepo.GetAllBookings();
            return Ok(b);
        }

        [HttpGet("GetBookingsWithDateRange")]
        public IActionResult GetBookingsWithDateRange(List<DateTime> d)
        {
            List<BookingModel1001> b = _bookingRepo.GetBookingsWithDateRange(d[0], d[1]);
            return Ok(b);
        }

        [HttpGet("GetBookingsWithDateRange")]
        public IActionResult GetEarningsWithDateRange(List<DateTime> d)
        {
            List<BookingModel1001> b = _bookingRepo.GetEarningsWithDateRange(d[0], d[1]);
            return Ok(b);
        }

        [HttpGet("GetBookingById")]
        public IActionResult GetBookingById(int bookingID)
        {
            BookingModel1001 b = _bookingRepo.GetBookingById(bookingID);
            return Ok(b);
        }

        [HttpDelete("RemoveBookingById")]
        public IActionResult RemoveBookingById(List<FlightModel1001> f, int bookingID)
        {
            _bookingRepo.RemoveBookingById(_flightRepo.GetAllFlights(), bookingID);
            return Ok("Success");
        }

        [HttpGet("GetCustomerDetailsByBookingId")]
        public IActionResult GetCustomerDetailsByBookingId(List<CustomerModel1001> c, int bookingID)
        {
            CustomerModel1001 c1 = _bookingRepo.GetCustomerDetailsByBookingId(_customerRepo.GetAllCustomers(), bookingID);
            return Ok(c1);
        }

        [HttpGet("GetAllFlightsWithSourceByBookingId")]
        public IActionResult GetAllFlightsWithSourceByBookingId(List<FlightModel1001> f, int bookingID)
        {
            List<FlightModel1001> f1 = _bookingRepo.GetAllFlightsWithSourceByBookingId(_flightRepo.GetAllFlights(), bookingID);
            return Ok(f1);
        }

        [HttpPost("AddPassengersToGivenBooking")]
        public IActionResult AddPassengersToGivenBooking(List<FlightModel1001> f, int bookingID, int numberOfPassengers)
        {
            _bookingRepo.AddPassengersToGivenBooking(_flightRepo.GetAllFlights(), bookingID, numberOfPassengers);
            return Ok("Success");
        }
    }
}
