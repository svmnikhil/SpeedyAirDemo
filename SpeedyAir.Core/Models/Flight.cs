namespace SpeedyAir.Core.Models
{
    public class Flight
    {
        public int FlightNumber { get; }
        public string DepartureCity { get; }
        public string ArrivalCity { get; }
        public int Day { get; }
        public int Capacity { get; }
        public int AvailableSpace { get; private set; }

        public Flight(int flightNumber, string departureCity, string arrivalCity, int day, int capacity = 20)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
            Capacity = capacity;
            AvailableSpace = capacity;
        }

        public bool CanAcceptOrder()
        {
            return AvailableSpace > 0;
        }

        public bool AllocateSpace()
        {
            if (!CanAcceptOrder()) return false;
            
            AvailableSpace--;
            return true;
        }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
        }
    }
}