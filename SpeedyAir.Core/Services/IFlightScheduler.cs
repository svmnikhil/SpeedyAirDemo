using SpeedyAir.Core.Models;

namespace SpeedyAir.Core.Services;

public interface IFlightScheduler
{
    IEnumerable<Flight> InitializeSchedule(int numberOfDays);
    IEnumerable<Flight> GetAvailableFlightsForDestination(string destination);
    int? ScheduleOrder(Order order);
    Flight? GetFlightByNumber(int flightNumber);
    void PrintSchedule();
}