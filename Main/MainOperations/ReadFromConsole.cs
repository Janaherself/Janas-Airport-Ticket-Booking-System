namespace JanasAirportTicketBookingSystem.Main.MainOperations
{
    public class ReadFromConsole
    {
        public static int GetFlightID()
        {
            Console.Write("Enter Flight ID: ");
            int flightid = Convert.ToInt32(Console.ReadLine());

            return flightid;
        }

        public static string GetUserName()
        {
            Console.Write("Enter your name: ");
            string? UserName = Console.ReadLine();

            return UserName;
        }

        public static string GetFlightClass()
        {
            Console.Write("Choose a class number:\n" +
                "1. First\n" +
                "2. Business\n" +
                "3. Economy\n");

            var classOption = Console.ReadLine();

            string flightClass = "";

            if (classOption == "1") { flightClass = "First"; }
            else if (classOption == "2") { flightClass = "Business"; }
            else if (classOption == "3") { flightClass = "Economy"; }

            if (string.IsNullOrWhiteSpace(flightClass)) return null;

            else return flightClass;
        }
    }
}
