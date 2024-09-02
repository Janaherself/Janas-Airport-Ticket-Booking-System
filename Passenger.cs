namespace JanasAirportTicketBookingSystem
{
    public class Passenger(string passengerName)
    {

        private static int _id = 1;
        public int Id { get; init; } = _id++;
        public string Name { get; set; } = passengerName;
        public List<Booking>? Bookings { get; set; }

        public override string ToString()
        {
            string bookingsList = "";
            if (Bookings?.Count > 0)
            {
                foreach (var booking in Bookings)
                {
                    bookingsList += $"Booking ID: {booking.BookingId}\n" +
                        $"Booking Date: {booking.BookingDate}\n" +
                        $"Flight ID: {booking.FlightId}\n\n";
                }
                return bookingsList;
            }
            else { return "You don't have any booking for now.\n"; }
        }
    }
}