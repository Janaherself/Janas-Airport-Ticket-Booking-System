﻿namespace JanasAirportTicketBookingSystem
{
    public class Flight
    {
        public required int FlightId { get; set; }
        public required decimal Price { get; set; }
        public required string DepartureCountry { get; set; }
        public required string DestinationCountry { get; set; }
        public required DateTime DepartureDate { get; set; }
        public required string DepartureAirport { get; set; }
        public required string ArrivalAirport { get; set; }
        public required FlightClass Class {  get; set; }
    }
}
