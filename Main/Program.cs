using JanasAirportTicketBookingSystem.Main.MainOperations;
using JanasAirportTicketBookingSystem.Manager;
using JanasAirportTicketBookingSystem.Passenger;

namespace JanasAirportTicketBookingSystem.Main
{
    public class Program
    {

        public static void Main(string[] args)
        {
            ShowMainMenu();
        }

        public static void ShowMainMenu()
        {
            Console.Clear();

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
                        Console.WriteLine("------------------------------------------\n");
                        break;
                }
            }
        }

        private static void PassengerMenu()
        {
            PassengerServices passengerServices = new();

            Console.Clear();

            string? passengerName = ReadFromConsole.GetUserName();

            Passenger.Passenger passenger = new(passengerName);

            Console.Clear();

            Console.WriteLine($"Welcome {passenger.Name}!\n");

            bool executing = true;

            while (executing)
            {
                Console.WriteLine("What are you up to today?");
                Console.WriteLine("1. Book a Flight\n" +
                    "2. Cancel a Booking\n" +
                    "3. Modify a Booking\n" +
                    "4. View Bookings\n" +
                    "5. Go Back to The Main Menu");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        passengerServices.BookingSection(passenger);
                        break;

                    case "2":
                        passengerServices.CancelSection(passenger);
                        break;

                    case "3":
                        passengerServices.ModifySection(passenger);
                        break;

                    case "4":
                        passengerServices.ViewBookings(passenger);
                        break;

                    case "5":
                        ShowMainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection! please try again.\n");
                        Console.WriteLine("------------------------------------------\n");
                        break;
                }
            }
        }

        private static void ManagerMenu()
        {
            ManagerServices managerServices = new();

            Console.Clear();

            string? managerName = ReadFromConsole.GetUserName();

            Manager.Manager manager = new(managerName);

            Console.Clear();

            Console.WriteLine($"Welcome {manager.Name}!\n");

            bool executing = true;

            while (executing)
            {
                Console.WriteLine("What are you up to today?");
                Console.WriteLine("1. Search for a Flight\n" +
                    "2. Import and Validate Flights Data\n" +
                    "3. Go Back to The Main Menu");
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
                        ShowMainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection! please try again.\n");
                        Console.WriteLine("------------------------------------------\n");
                        break;
                }
            }
        }
    }
}
