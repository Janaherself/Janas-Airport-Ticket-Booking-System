namespace JanasAirportTicketBookingSystem
{
    public static class ClassPriceExtensions
    {
        public static ClassPrice GetClassPrice (this FlightClass flightClass)
        {
            return flightClass switch
            {
                FlightClass.First => ClassPrice.FirstPrice,
                FlightClass.Business => ClassPrice.BusinessPrice,
                FlightClass.Economy => ClassPrice.EconomyPrice,
                _ => throw new Exception("Invalid Class!")
            };
        }
    }
}
