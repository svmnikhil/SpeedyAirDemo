using SpeedyAir.Core.Models;

namespace SpeedyAir.Core.Repositories;

public interface IOrderRepository
{
    // we should get all orders from the json file and return them as a list of Order objects
    Task<IEnumerable<Order>> GetOrders();
    // aspirational: we should be able to update the order status once a flight number is assigned
}