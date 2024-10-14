namespace JanasAirportTicketBookingSystem.Manager
{
    public record Manager(string managerName)
    {
        private static int _id = 1;
        public int Id { get; init; } = _id++;
        public string Name { get; set; } = managerName;
    }
}
