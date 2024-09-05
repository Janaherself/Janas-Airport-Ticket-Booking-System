using JanasAirportTicketBookingSystem.Flight;
using JanasAirportTicketBookingSystem.Main.MainOperations;

namespace JanasAirportTicketBookingSystem.Passenger
{
    public class PassengerServices
    {
        public void BookingSection(Passenger passenger)
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
            else
            {
                var flightClass = ReadFromConsole.GetFlightClass();
                var flightId = ReadFromConsole.GetFlightID();

                if (!string.IsNullOrEmpty(flightClass) && FlightServices.Flights.ContainsKey(flightId))
                {
                    BookFlight(passenger, flightId, flightClass);
                }
                else 
                { 
                    Console.WriteLine("Invalid flight Id or flight class.\n");
                    Console.WriteLine("------------------------------------------\n");
                }
            }
        }

        public static void BookFlight(Passenger passenger, int flightID, string flightclass)
        {
            passenger.Bookings?.Add(new Booking.Booking(flightID, passenger.Id, flightclass, DateTime.Now));

            Console.WriteLine("Booked Successfully!\n");
            Console.WriteLine("------------------------------------------\n");

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

        public static void CancelBooking(int flightID, Passenger passenger)
        {
            passenger.Bookings?.RemoveAll(item => item.FlightId == flightID);

            Console.WriteLine("Cancelled Successfully!\n");
            Console.WriteLine("------------------------------------------\n");
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

        public void ViewBookings(Passenger passenger)
        {
            if (passenger.Bookings?.Count > 0)
            {
                Console.WriteLine("Your current list of bookings: \n");

                foreach (var booking in passenger.Bookings)
                {
                    Console.WriteLine($"{booking.ToString()}");
                }
            }
            else 
            { 
                Console.WriteLine("You don't have any bookings right now.\n");
                Console.WriteLine("------------------------------------------\n");
            }

        }
    }
}
