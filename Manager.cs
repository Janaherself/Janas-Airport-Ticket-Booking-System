namespace JanasAirportTicketBookingSystem
{
    public class Manager(string managerName)
    {
        private static int _id = 1;
        public int Id { get; private set; } = _id++;
        public string Name { get; set; } = managerName;
    }
}
