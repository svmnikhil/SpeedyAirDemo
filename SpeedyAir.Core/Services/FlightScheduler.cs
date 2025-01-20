using Microsoft.Extensions.Configuration;
using SpeedyAir.Core.Models;

namespace SpeedyAir.Core.Services;

public class FlightScheduler : IFlightScheduler
{
    private readonly IConfiguration _configuration;
    private readonly List<Flight> _flights;
    private readonly string _departureAirport;

    public FlightScheduler(IConfiguration configuration)
    {
        _configuration = configuration;
        _flights = new List<Flight>();
        _departureAirport = configuration.GetValue<string>("FlightSettings:DepartureAirport") ?? "YUL";
    }
    
    public IEnumerable<Flight> InitializeSchedule(int numberOfDays)
    {
        _flights.Clear(); //clear any existing flights
        
        //define the daily routes leaving from YUL
        var dailyRoutesYul = new[]
        {
            new { arrival = "YYZ", flightOffset = 0 },
            new { arrival = "YYC", flightOffset = 1 },
            new { arrival = "YVR", flightOffset = 2 }
        };

        for (int day = 1; day <= numberOfDays; day++)
        {   
            //create flights for each day from YUL to other destinations
            foreach(var route in dailyRoutesYul)
            {
                // day-1 to start from 1 and day+1 to prevent starting from 0
                var flightNumber = (day - 1) * dailyRoutesYul.Length + route.flightOffset + 1;
                var flight = new Flight(flightNumber, _departureAirport, route.arrival, day);
                _flights.Add(flight);
            }
        }

        return _flights;
    }
    
    public int? ScheduleOrder(Order order)
    {
        var flight = _flights.FirstOrDefault(f => f.ArrivalCity == order.destination && f.CanAcceptOrder());
        if (flight == null) return null;
        
        flight.AllocateSpace();
        return flight.FlightNumber;
    }
    
    public Flight? GetFlightByNumber(int flightNumber)
    {
        var flight = _flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        return flight;
    }
    
    public void PrintSchedule()
    {
        foreach (var flight in _flights)
        {
            Console.WriteLine(flight);
        }
    }
}