using WebApplication1.Models;
using Microsoft.AspNetCore.JsonPatch;
namespace WebApplication1.Repo
{
    public interface IFlightRepo1001
    {
        void AddFlight(FlightModel1001 flight);
        void AddBulkFlights(List<FlightModel1001> flights);
        List<FlightModel1001> GetAllFlights();
        FlightModel1001 GetFlightWithID(int flightID);
        List<FlightModel1001> GetFlightsWithSource(string source);
        int GetRemainingCapacity(int flightID);
        void UpdateFlight(int flightID, JsonPatchDocument<FlightModel1001> patch);
        void RemoveFlightById(List<BookingModel1001> b, int flightID);
    }
    public class FlightRepo1001 : IFlightRepo1001
    {
        private List<FlightModel1001> _flights;

        public FlightRepo1001()
        {
            _flights = new List<FlightModel1001> ();
        }
        public void AddFlight(FlightModel1001 flight)
        {
            //flight.FlightID = _flights.Count + 1;
            _flights.Add(flight);
        }

        public void AddBulkFlights(List<FlightModel1001> flights)
        {
            for(int i = 0; i < flights.Count; i++)
            {
                //flights[i].FlightID = _flights.Count + 1;
                _flights.Add(flights[i]);
            }
        }

        public List<FlightModel1001> GetAllFlights()
        {
            return _flights;
        }

        public FlightModel1001 GetFlightWithID(int flightID)
        {
            for(int i = 0; i < _flights.Count; i++)
            {
                if(_flights[i].FlightID == flightID) return _flights[i];
            }
            return null;
        }

        public List<FlightModel1001> GetFlightsWithSource(string source)
        {
            List<FlightModel1001> l = new List<FlightModel1001>();
            for(int i = 0; i < _flights.Count;i++)
            {
                if (_flights[i].Source.Equals(source)) l.Add(_flights[i]);
            }
            return l;
        }

        public int GetRemainingCapacity(int flightID)
        {
            for(int i = 0; i  < _flights.Count; i++)
            {
                if (_flights[i].FlightID == flightID) return _flights[i].MaxCapacity - _flights[i].CurrentlyBooked;
            }
            return 0;
        }

        public void UpdateFlight(int flightID, JsonPatchDocument<FlightModel1001> patch)
        {
            for(int i = 0; i < _flights.Count; i++)
            {
                if (_flights[i].FlightID == flightID)
                {
                    patch.ApplyTo(_flights[i]);
                    return;
                }
            }
        }

        public void RemoveFlightById(List<BookingModel1001> b, int flightID)
        {
            for(int i = 0; i < b.Count; i++)
            {
                if (b[i].FlightID == flightID)
                {
                    b.Remove(b[i]);
                }
            }
            for(int i = 0; i < _flights.Count; i++)
            {
                if (_flights[i].FlightID == flightID)
                {
                    _flights.Remove(_flights[i]);
                    break;
                }
            }
        }
    }
}
