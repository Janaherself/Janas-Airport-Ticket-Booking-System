using System.Linq;

namespace JanasAirportTicketBookingSystem.Flight
{
    public class FlightServices
    {
        private readonly IUserInput _userInput;

        public FlightServices()
        {
        }

        public FlightServices(IUserInput userInput)
        {
            _userInput = userInput;
        }

        public static Dictionary<int, Flight> Flights { get; set; } = [];

        public List<Flight> FilterFlights ()
        {
            Dictionary<string, string> searchPrompts = new()
            {
                { "DepartureCountry", "1. Departure Country" },
                { "DestinationCountry", "2. Destination Country" },
                { "DepartureAirport", "3. Departure Airport" },
                { "ArrivalAirport", "4. Arrival Airport" },
                { "DepartureDate", "5. Departure Date (in the format: MM/dd/yyyy HH:mm)" },
                { "Price", "6. Price" },
            };

            Console.WriteLine("Enter the values to search for, " +
                "you can leave any value empty if you don't want to include it in the search\n");

            Dictionary<string, string> searchParameters = [];

            foreach (var parameter in searchPrompts)
            {
                Console.Write($"{parameter.Value}: ");
                searchParameters.Add(parameter.Key, _userInput.ReadLine());
            }

            var query = new List<Flight>(Flights.Values);

            if (!string.IsNullOrWhiteSpace(searchParameters["DepartureCountry"]))
            { query = query.Where(p => p.DepartureCountry.Contains(searchParameters["DepartureCountry"],
                StringComparison.CurrentCultureIgnoreCase)).ToList(); }

            if (!string.IsNullOrWhiteSpace(searchParameters["DestinationCountry"]))
            { query = query.Where(p => p.DestinationCountry.Contains(searchParameters["DestinationCountry"],
                StringComparison.CurrentCultureIgnoreCase)).ToList(); }

            if (!string.IsNullOrWhiteSpace(searchParameters["DepartureAirport"]))
            { query = query.Where(p => p.DepartureAirport.Contains(searchParameters["DepartureAirport"], 
                StringComparison.CurrentCultureIgnoreCase)).ToList(); }

            if (!string.IsNullOrWhiteSpace(searchParameters["ArrivalAirport"]))
            { query = query.Where(p => p.ArrivalAirport.Contains(searchParameters["ArrivalAirport"],
                StringComparison.CurrentCultureIgnoreCase)).ToList(); }

            if (!string.IsNullOrWhiteSpace(searchParameters["DepartureDate"]))
            { query = query.Where(p => p.DepartureDate == Convert.ToDateTime(searchParameters["DepartureDate"])).ToList(); }

            if (!string.IsNullOrWhiteSpace(searchParameters["Price"]))
            {
                query = query.Where(p => p.FirstClassPrice >= Convert.ToDecimal(searchParameters["Price"]) &&
                p.EconomyClassPrice <= Convert.ToDecimal(searchParameters["Price"])).ToList();
            }

            return query;
        }
    }
}
