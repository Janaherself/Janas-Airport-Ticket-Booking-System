namespace JanasAirportTicketBookingSystem
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public DateTime FlightDate { get; set; }

    }
}
