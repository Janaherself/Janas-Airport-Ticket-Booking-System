namespace JanasAirportTicketBookingSystem
{
    public class PassengerServices
    {
        public string BookFlight(int flightID)
        {
            string message = "";

            ViewFlights();



            return message;
        }

        public string CancelFlight(int flightID)
        {
            string message = "";

            ViewFlights();



            return message;
        }

        public string ModifyFlight(int flightID)
        {
            string message = "";

            ViewFlights();



            return message;
        }

        public void ViewFlights()
        {    
            FileManager fileManager = new FileManager();

            if (fileManager.Flights.Count > 0)
            {
                foreach (var flight in fileManager.Flights.Values)
                {
                    Console.WriteLine($"Flight: {flight.FlightId}\n" +
                        $"From {flight.DepartureAirport} in {flight.DepartureCountry}\n" +
                        $"To {flight.ArrivalAirport} in {flight.DestinationCountry}\n" +
                        $"Departure Date: {flight.DepartureDate}\n" +
                        $"Class: {flight.Class}\n" +
                        $"{flight.Price}$");
                }
            }
            else { Console.WriteLine("Sorry, there are no flights currently in the system!\n"); }
        }

        public void ViewBookings(Passenger passenger)
        {
            if (passenger.Bookings?.Count > 0)
            {
                foreach (var booking in passenger.Bookings)
                {
                    Console.WriteLine($"{booking.ToString()}");
                }
            }
            else { Console.WriteLine("You don't have any bookings right now\n"); }

        }
    }
}
