using System.Text;
using JanasAirportTicketBookingSystem.Data;
using JanasAirportTicketBookingSystem.Flight;

namespace JanasAirportTicketBookingSystem.Manager
{
    public class ManagerServices
    {
        public List<Flight.Flight> FilterFlights()
        {
            var query = FlightServices.FilterFlights();

            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }

            if (query.Count <= 0)
            { 
                Console.WriteLine("no flights match the filters you entered!\n");
                Console.WriteLine("------------------------------------------\n");
            }

            return query;
        }

        public void ImportFlightsData()
        {
            FileManager.ImportData();
        }
    }
}
