namespace JanasAirportTicketBookingSystem.Flight
{
    public class Flight
    {
        public Flight() { }

        public Flight(int flightId, string departureCountry, string destinationCountry,
            DateTime departureDate, string departureAirport, string arrivalAirport, 
            decimal firstClassPrice, decimal businessClassPrice, decimal economyClassPrice) 
        {
            FlightId = flightId;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            FirstClassPrice = firstClassPrice;
            BusinessClassPrice = businessClassPrice;
            EconomyClassPrice = economyClassPrice;
        }

        public required int FlightId { get; set; }
        public required string DepartureCountry { get; set; }
        public required string DestinationCountry { get; set; }
        public required DateTime DepartureDate { get; set; }
        public required string DepartureAirport { get; set; }
        public required string ArrivalAirport { get; set; }
        public required decimal FirstClassPrice {  get; set; }
        public required decimal BusinessClassPrice {  get; set; }
        public required decimal EconomyClassPrice { get; set; }

        public override string ToString()
        {
            return $"Flight: {FlightId}\n" +
                $"From {DepartureAirport} in {DepartureCountry}\n" +
                $"To {ArrivalAirport} in {DestinationCountry}\n" +
                $"Departure Date: {DepartureDate}\n" +
                $"Classes' Prices: \n" +
                $"First Class: {FirstClassPrice}$\n" +
                $"Business Class: {BusinessClassPrice}$\n" +
                $"Economy Class: {EconomyClassPrice}$\n" +
                $"-\n";

        }
    }
}
