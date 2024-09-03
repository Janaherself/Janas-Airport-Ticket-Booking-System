namespace JanasAirportTicketBookingSystem
{
    public class Booking
    {
        public Booking(int flightID, int passengerID, DateTime dateTime) 
        {
            BookingId = _id++;
            FlightId = flightID;
            PassengerId = passengerID;
            BookingDate = dateTime;
        }

        private static int _id = 1;
        public int BookingId { get; private set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
