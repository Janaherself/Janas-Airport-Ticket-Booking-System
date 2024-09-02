namespace JanasAirportTicketBookingSystem
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
    }
}
