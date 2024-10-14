namespace JanasAirportTicketBookingSystem.Booking
{
    public class Booking
    {
        public Booking(int flightID, int passengerID, FlightClass flightClass, DateTime dateTime)
        {
            BookingId = _id++;
            FlightId = flightID;
            PassengerId = passengerID;
            FlightClass = flightClass;
            BookingDate = dateTime;
        }

        public Booking(int flightID, int passengerID, FlightClass flightClass)
        {
            BookingId = _id++;
            FlightId = flightID;
            PassengerId = passengerID;
            FlightClass = flightClass;
        }

        private static int _id = 1;
        public int BookingId { get; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public FlightClass FlightClass { get; set; }
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
