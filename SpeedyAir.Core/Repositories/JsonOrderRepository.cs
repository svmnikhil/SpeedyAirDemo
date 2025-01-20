using Microsoft.Extensions.Configuration;
using SpeedyAir.Core.Models;
using Newtonsoft.Json.Linq;


namespace SpeedyAir.Core.Repositories;

public class JsonOrderRepository : IOrderRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _jsonFilePath;

    public JsonOrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _jsonFilePath = configuration.GetValue<string>("OrderSettings:OrdersFilePath") ?? "orders.json";
    }
    
    public async Task<IEnumerable<Order>> GetOrders()
    {
        try
        {
            // open the file contents
            var jsonContent = await File.ReadAllTextAsync(_jsonFilePath);
            var ordersObject = JObject.Parse(jsonContent);

            // convert to order objects
            var orders = ordersObject.Properties()
                .Select(p => new Order(
                    p.Name,
                    p.Value["destination"]?.ToString() ?? string.Empty
                ))
                .ToList();
            
            return orders;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading orders: {ex.Message}");
            return Enumerable.Empty<Order>();
        }
    }
    
}