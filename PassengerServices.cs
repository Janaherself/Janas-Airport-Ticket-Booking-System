namespace JanasAirportTicketBookingSystem
{
    public class PassengerServices
    {
        public void BookingSection(Passenger passenger)
        {
            FlightsManager flightsManager = new FlightsManager();
            IEnumerable<Flight> query = flightsManager.Flights.Values.ToList();
            Dictionary<string, string> searchParameters = new();

            Dictionary<string, string> searchPrompts = new()
            {
                { "DepartureCountry", "1. Departure Country" },
                { "DestinationCountry", "2. Destination Country" },
                { "DepartureAirport", "3. Departure Airport" },
                { "ArrivalAirport", "4. Arrival Airport" },
                { "DepartureDate", "5. Departure Date (in the format: MM/dd/yyyy HH:mm)" },
                { "Price", "6. Price" },
                { "Class", "7. Class" }
            };

            Console.WriteLine("Enter the values to search for, " +
                "you can leave any value empty if you don't want to include it in the search\n");

            foreach (var parameter in searchPrompts)
            {
                Console.Write($"{parameter.Value}: ");
                searchParameters.Add(parameter.Key, Console.ReadLine());
            }

            Dictionary<string, Func<Flight, bool>> queryConditions = new()
            {
                { "DestinationCountry", p => p.DestinationCountry == searchParameters["DestinationCountry"] },
                { "DepartureAirport", p => p.DepartureAirport == searchParameters["DepartureAirport"] },
                { "ArrivalAirport", p => p.ArrivalAirport == searchParameters["ArrivalAirport"] },
                { "DepartureDate", p => p.DepartureDate == Convert.ToDateTime(searchParameters["DepartureDate"]) },
                { "Price", p => p.Price == Convert.ToDecimal(searchParameters["Price"]) },
                { "Class", p => p.Class == searchParameters["Class"] }
            };

            foreach (var parameter in searchParameters)
            {
                if (!string.IsNullOrEmpty(parameter.Value))
                {
                    try 
                    {
                        query = query.Where(queryConditions[parameter.Key]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No Flights were found that match the filters you entered!\n");
                    }
                }
            }
            
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }

            BookFlight(ReadFromConsole.GetFlightID(), passenger);
        }

        public string BookFlight(int flightID, Passenger passenger)
        {
            passenger.Bookings?.Add(new Booking(flightID, passenger.Id, DateTime.Now));

            return "Booked Successfully!\n";
        }

        public void CancelSection(Passenger passenger)
        {
            ViewBookings(passenger);

            if (passenger.Bookings?.Count > 0)
            {
                var flightIDToCancel = ReadFromConsole.GetFlightID();

                Console.Write("Are you sure you want to cancel the booking? (type y for yes, n for no) ");
                var key = Console.ReadKey();

                Console.WriteLine();

                if (key.KeyChar == 'y')
                {
                    CancelBooking(flightIDToCancel, passenger);
                }
            }
        }

        public string CancelBooking(int flightID, Passenger passenger)
        {
            passenger.Bookings?.RemoveAll(item => item.FlightId == flightID);

            return "Cancelled Successfully!\n";
        }

        public void ModifySection(Passenger passenger)
        {
            ViewBookings(passenger);

            if (passenger.Bookings?.Count > 0) 
            {
                var flightIDToCancel = ReadFromConsole.GetFlightID();

                Console.Write("Are you sure you want to cancel this booking and book another flight? " +
                    "(type y for yes, n for no) ");
                var key = Console.ReadKey();

                Console.WriteLine();

                if (key.KeyChar == 'y')
                {
                    CancelBooking(flightIDToCancel, passenger);

                    BookingSection(passenger);
                }
            }
        }

        public void ViewFlights()
        {    
            FlightsManager flightManager = new();

            if (flightManager.Flights.Count > 0)
            {
                foreach (var flight in flightManager.Flights.Values)
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
            else { Console.WriteLine("You don't have any bookings right now.\n"); }

        }
    }
}
