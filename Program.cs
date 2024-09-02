namespace JanasAirportTicketBookingSystem
{
    public class Program
    {

        public static void Main(String[] args)
        {
            Console.WriteLine("Hello There!");
            bool executing = true;

            while (executing)
            { 
                Console.WriteLine("1. I'm a Passenger\n" +
                    "2. I'm a Manager\n" + 
                    "3. I just want to exit!");
                Console.Write("Choose the number of the option that best suits you: ");
                string? user = Console.ReadLine();

                Console.WriteLine();

                switch (user)
                {
                    case "1":
                        PassengerMenu();
                        break;

                    case "2":
                        ManagerMenu();
                        break;

                    case "3":
                        executing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection! please try again.\n");
                        break;
                }
            }
        }

        private static void PassengerMenu()
        {
            PassengerServices passengerServices = new PassengerServices();

            Console.Clear();
            Console.Write("Enter your name: ");
            string? passengerName = Console.ReadLine();

            Passenger passenger = new(passengerName);

            Console.WriteLine();

            Console.WriteLine($"Welcome {passenger.Name}!\n");

            bool executing = true;

            while (executing)
            {
                Console.WriteLine("What are you up to today?");
                Console.WriteLine("1. Book a Flight\n" +
                    "2. Cancel a Flight\n" +
                    "3. Modify a Flight\n" +
                    "4. View Bookings");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        int flightid = UserInput();
                        passengerServices.BookFlight(flightid);
                        break;

                    case "2":
                        int flightIDToCancel = UserInput();
                        passengerServices.CancelFlight(flightIDToCancel);
                        break;

                    case "3":
                        int flightIDToModify = UserInput();
                        passengerServices.ModifyFlight(flightIDToModify);
                        break;

                    case "4":
                        ViewBookings(passenger);
                        break;

                    default:
                        Console.WriteLine("Invalid Selection! please try again.\n");
                        break;
                }
            }
        }

        private static void ManagerMenu()
        {
            ManagerServices managerServices = new ManagerServices();
            
            Console.Clear();
            Console.Write("Enter your name: ");
            string? managerName = Console.ReadLine();

            Manager manager = new(managerName);

            Console.WriteLine();

            Console.WriteLine($"Welcome {manager.Name}!\n");

            bool executing = true;

            while (executing)
            {
                Console.WriteLine("What are you up to today?");
                Console.WriteLine("1. Search for a Flight.\n" +
                    "2. Import Flights Data.\n" +
                    "3. View Validation Details.\n");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        managerServices.FilterFlights();
                        break;

                    case "2":
                        managerServices.ImportFlightsData();
                        break;

                    case "3":
                        managerServices.GetValidationDetails();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection! please try again.\n");
                        break;
                }
            }
        }

        private static void ViewBookings(Passenger passenger)
        {
            if (passenger.Bookings.Count > 0)
            {
                foreach (string booking in passenger.Bookings)
                {
                    Console.WriteLine($"{booking}");
                }
            }
            else { Console.WriteLine("You don't have any bookings right now\n"); }

        }

        public static int UserInput()
        {
            Console.Write("Enter Flight ID: ");
            int flightid = Convert.ToInt32(Console.ReadLine());
            return flightid;
        }
    }
}
