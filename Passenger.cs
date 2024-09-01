namespace JanasAirportTicketBookingSystem
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public List<string> PassengerBookings { get; set; }
    }
}
