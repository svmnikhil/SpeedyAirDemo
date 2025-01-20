namespace SpeedyAir.Core.Models;

public class Order
{
    public string orderId { get; set; }
    public string destination { get; set; }

    public Order(string orderId, string destination)
    {
        this.orderId = orderId;
        this.destination = destination;
    }
}