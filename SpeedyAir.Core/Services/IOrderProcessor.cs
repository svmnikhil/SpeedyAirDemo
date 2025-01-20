using SpeedyAir.Core.Models;

namespace SpeedyAir.Core.Services;

public interface IOrderProcessor
{
    // processing an order involves parsing the json file to convert each json object into an Order object
    Task ProcessOrders();
}