namespace JanasAirportTicketBookingSystem
{
    public class Flight
    {
        public Flight() { }

        public Flight(string departureCountry, string destinationCountry, DateTime departureDate, 
            string departureAirport, string arrivalAirport, Dictionary<string, decimal> classPrice) 
        {
            FlightId = _id++;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            ClassPrice = classPrice;
        }

        private static int _id = 1;
        public  int FlightId { get; private set; }
        public required string DepartureCountry { get; set; }
        public required string DestinationCountry { get; set; }
        public required DateTime DepartureDate { get; set; }
        public required string DepartureAirport { get; set; }
        public required string ArrivalAirport { get; set; }
        public required Dictionary<string, decimal> ClassPrice { get; set; }
        public required string Class {  get; set; }
        public required decimal Price {  get; set; }


        public override string ToString()
        {
            return $"Flight: {FlightId}\n" +
                $"From {DepartureAirport} in {DepartureCountry}\n" +
                $"To {ArrivalAirport} in {DestinationCountry}\n" +
                $"Departure Date: {DepartureDate}\n" +
                $"Classes: \n" +
                $"{ClassPrice.ElementAt(0)}\n" +
                $"{ClassPrice.ElementAt(1)}\n" +
                $"{ClassPrice.ElementAt(2)}\n";

        }
    }
}
