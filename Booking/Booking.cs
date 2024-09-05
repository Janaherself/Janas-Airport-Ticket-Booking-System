namespace JanasAirportTicketBookingSystem.Booking
{
    public class Booking
    {
        public Booking(int flightID, int passengerID, string flightClass, DateTime dateTime)
        {
            BookingId = _id++;
            FlightId = flightID;
            PassengerId = passengerID;
            FlightClass = flightClass;
            BookingDate = dateTime;
        }

        private static int _id = 1;
        public int BookingId { get; private set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public string FlightClass { get; set; }
        public DateTime BookingDate { get; set; }

        public override string ToString()
        {
            return $"Booking ID: {BookingId}\n" +
                $"Flight ID: {FlightId}\n" +
                $"Ticket Class: {FlightClass}\n" +
                $"Booking Date: {BookingDate}\n" +
                $"-\n";
        }
    }
}
