namespace JanasAirportTicketBookingSystem
{
    public class Passenger(string passengerName)
    {

        private static int _id = 1;
        public int Id { get; init; } = _id++;
        public string Name { get; set; } = passengerName;
        public List<string>? Bookings { get; set; }
    }
}
