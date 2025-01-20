using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SpeedyAir.Core.Models;
using SpeedyAir.Core.Repositories;
using SpeedyAir.Core.Services;

namespace SpeedyAir.Console;
class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:false)
            .Build();

        //dependency injection setup
        var serviceProvider = new ServiceCollection()
            .AddSingleton(configuration)
            .AddSingleton<IFlightScheduler, FlightScheduler>()
            .AddSingleton<IOrderProcessor, OrderProcessor>()
            .AddSingleton<IOrderRepository, JsonOrderRepository>()
            .BuildServiceProvider();
        
        var flightScheduler = serviceProvider.GetRequiredService<IFlightScheduler>();
        var orderProcessor = serviceProvider.GetRequiredService<IOrderProcessor>();
        
        var flights = flightScheduler.InitializeSchedule(2);

        System.Console.WriteLine("Flight Schedule:");
        flightScheduler.PrintSchedule();
        
        System.Console.WriteLine("\nOrder Scheduling:");
        await orderProcessor.ProcessOrders();
    }
}