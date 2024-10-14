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
            var csvFilePath = $@"..\..\..\Data\flights.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var options = new TypeConverterOptions { Formats = ["MM/dd/yyyy HH:mm"] };
                csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

                var flights = csv.GetRecords<Flight.Flight>();

                List<string> errors = [];
                foreach (var flight in flights)
                {
                    FlightServices.Flights.Add(flight.FlightId, flight);

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

        public static string ValidateData(Flight.Flight flight)
        {
            if (string.IsNullOrEmpty(flight.DepartureAirport) || flight.DepartureAirport.GetType() != typeof(string))
            {
                return $"{flight.FlightId}. Departure Airport value is required and must be of type string";
            }
            if (string.IsNullOrEmpty(flight.DepartureCountry) || flight.DepartureCountry.GetType() != typeof(string))
            {
                return $"{flight.FlightId}. Departure Country value is required and must be of type string";
            }
            if (string.IsNullOrEmpty(flight.ArrivalAirport) || flight.ArrivalAirport.GetType() != typeof(string))
            {
                return $"{flight.FlightId}. Arrival Airport value is required and must be of type string";
            }
            if (string.IsNullOrEmpty(flight.DestinationCountry) || flight.DestinationCountry.GetType() != typeof(string))
            {
                return $"{flight.FlightId}. Destination Country value is required and must be of type string";
            }
            if (flight.FlightId == 0 || flight.FlightId.GetType() != typeof(int))
            {
                return $"{flight.FlightId}. Flight ID value is required and must be of type int and graeter than zero.";
            }
            if (flight.DepartureDate <= DateTime.Now || flight.DepartureDate.GetType() != typeof(DateTime))
            {
                return $"{flight.FlightId}. Departure Date value is required and must be of type datetime and later than today.";
            }
            if (flight.FirstClassPrice == 0 || flight.FirstClassPrice.GetType() != typeof(decimal))
            {
                return $"{flight.FlightId}. First Class Price value is required and must be of type decimal and graeter than zero.";
            }
            if (flight.BusinessClassPrice == 0 || flight.BusinessClassPrice.GetType() != typeof(decimal))
            {
                return $"{flight.FlightId}. Business Class Price value is required and must be of type decimal and graeter than zero.";
            }
            if (flight.EconomyClassPrice == 0 || flight.EconomyClassPrice.GetType() != typeof(decimal))
            {
                return $"{flight.FlightId}. Economy Class Price value is required and must be of type decimal and graeter than zero.";
            }
            return null;
        }
    }
}
