using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    [Route("Flight")]
    [ApiController]
    public class FlightController1001 : ControllerBase
    {
        private readonly IFlightRepo1001 _flightRepo;
        private readonly IBookingRepo1001 _bookingRepo;

        public FlightController1001(IFlightRepo1001 flightRepo, IBookingRepo1001 bookingRepo)
        {
            _flightRepo = flightRepo;
            _bookingRepo = bookingRepo;
        }

        [HttpPost("AddFlight")]
        public IActionResult AddFlight(FlightModel1001 flight)
        {
            _flightRepo.AddFlight(flight);
            return Ok("Success");
        }

        [HttpPost("AddBulkFlights")]
        public IActionResult AddBulkFlights(List<FlightModel1001> flights)
        {
            _flightRepo.AddBulkFlights(flights);
            return Ok("Success");
        }

        [HttpGet("GetAllFlights")]
        public IActionResult GetAllFlights()
        {
            List<FlightModel1001> l = _flightRepo.GetAllFlights();
            return Ok(l);
        }

        [HttpGet("GetFlightWithID")]
        public IActionResult GetFlightWithID(int flightID)
        {
            FlightModel1001 f = _flightRepo.GetFlightWithID(flightID);
            return Ok(f);
        }

        [HttpGet("GetFlightsWithSource")]
        public IActionResult GetFlightsWithSource(string source)
        {
            List<FlightModel1001> f = _flightRepo.GetFlightsWithSource(source);
            return Ok(f);
        }

        [HttpGet("GetRemainingCapacity")]
        public IActionResult GetRemainingCapacity(int flightID)
        {
            int i = _flightRepo.GetRemainingCapacity(flightID);
            return Ok(i);
        }

        [HttpPatch("UpdateFlight")]
        public IActionResult UpdateFlight(int flightID, JsonPatchDocument<FlightModel1001> patch)
        {
            _flightRepo.UpdateFlight(flightID, patch);
            return Ok("Success");
        }

        [HttpDelete("RemoveFlightById")]
        public IActionResult RemoveFlightById(int flightID)
        {
            _flightRepo.RemoveFlightById(_bookingRepo.GetAllBookings(), flightID);
            return Ok("Success");
        }
    }
}
