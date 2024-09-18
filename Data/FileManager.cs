using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using JanasAirportTicketBookingSystem.Flight;
using System.Globalization;

namespace JanasAirportTicketBookingSystem.Data
{
    public class FileManager
    {
        public static void ImportData()
        {
            var csvFilePath = $@"C:\Users\Jana\source\repos\JanasAirportTicketBookingSystem\Data\flights.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var options = new TypeConverterOptions { Formats = ["MM/dd/yyyy HH:mm"] };
                csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

                var flights = csv.GetRecords<Flight.Flight>();

                foreach (var flight in flights)
                {
                    FlightServices.Flights.Add(flight.FlightId, flight);
                }

                List<string> errors = [];
                foreach (var flight in FlightServices.Flights)
                {
                    var error = ValidateData(flight);
                    if (error != null)
                    {
                        errors.Add(error);
                    }
                }

                if (errors.Count > 0)
                {
                    Console.WriteLine($"{string.Join("\n", errors)}\n");
                }

                if (FlightServices.Flights.Count > 0)
                {
                    Console.WriteLine("Data imported successfully!\n");
                    Console.WriteLine("------------------------------------------\n");
                }
            }
        }

        public static string ValidateData(KeyValuePair<int, Flight.Flight> flight)
        {
            if (string.IsNullOrEmpty(flight.Value.DepartureAirport) || flight.Value.DepartureAirport.GetType() != typeof(string))
            {
                return $"{flight.Key}. Departure Airport value is required and must be of type string";
            }
            if (string.IsNullOrEmpty(flight.Value.DepartureCountry) || flight.Value.DepartureCountry.GetType() != typeof(string))
            {
                return $"{flight.Key}. Departure Country value is required and must be of type string";
            }
            if (string.IsNullOrEmpty(flight.Value.ArrivalAirport) || flight.Value.ArrivalAirport.GetType() != typeof(string))
            {
                return $"{flight.Key}. Arrival Airport value is required and must be of type string";
            }
            if (string.IsNullOrEmpty(flight.Value.DestinationCountry) || flight.Value.DestinationCountry.GetType() != typeof(string))
            {
                return $"{flight.Key}. Destination Country value is required and must be of type string";
            }
            if (flight.Value.FlightId == 0 || flight.Value.FlightId.GetType() != typeof(int))
            {
                return $"{flight.Key}. Flight ID value is required and must be of type int and graeter than zero.";
            }
            if (flight.Value.DepartureDate <= DateTime.Now || flight.Value.DepartureDate.GetType() != typeof(DateTime))
            {
                return $"{flight.Key}. Departure Date value is required and must be of type datetime and later than today.";
            }
            if (flight.Value.FirstClassPrice == 0 || flight.Value.FirstClassPrice.GetType() != typeof(decimal))
            {
                return $"{flight.Key}. First Class Price value is required and must be of type decimal and graeter than zero.";
            }
            if (flight.Value.BusinessClassPrice == 0 || flight.Value.BusinessClassPrice.GetType() != typeof(decimal))
            {
                return $"{flight.Key}. Business Class Price value is required and must be of type decimal and graeter than zero.";
            }
            if (flight.Value.EconomyClassPrice == 0 || flight.Value.EconomyClassPrice.GetType() != typeof(decimal))
            {
                return $"{flight.Key}. Economy Class Price value is required and must be of type decimal and graeter than zero.";
            }
            return null;
        }
    }
}
