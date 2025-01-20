using SpeedyAir.Core.Repositories;
using SpeedyAir.Core.Models;

namespace SpeedyAir.Core.Services;

public class OrderProcessor : IOrderProcessor
{
    private readonly IOrderRepository _orderRepository;
    private readonly IFlightScheduler _flightScheduler;
    
    public OrderProcessor(IOrderRepository orderRepository, IFlightScheduler flightScheduler)
    {
        _orderRepository = orderRepository;
        _flightScheduler = flightScheduler;
    }
    
    

    public async Task ProcessOrders()
    {
        var orders = await _orderRepository.GetOrders();

        foreach (var order in orders)
        {
            var flightNumber = _flightScheduler.ScheduleOrder(order);

            PrintOrderResult(order, flightNumber);
        }
    }
    
    
    private void PrintOrderResult(Order order, int? flightNumber)
    {
        if (!flightNumber.HasValue)
        {
            Console.WriteLine($"{order.orderId}, flightNumber: not scheduled");
            return;
        }

        var flight = _flightScheduler.GetFlightByNumber(flightNumber.Value);
        if (flight == null)
        {
            Console.WriteLine($"{order.orderId}, flightNumber: invalid flight {flightNumber}");
            return;
        }

        Console.WriteLine(
            $"{order.orderId}, " +
            $"flightNumber: {flight.FlightNumber}, " +
            $"departure: {flight.DepartureCity}, " +
            $"arrival: {flight.ArrivalCity}, " +
            $"day: {flight.Day}");
    }
}