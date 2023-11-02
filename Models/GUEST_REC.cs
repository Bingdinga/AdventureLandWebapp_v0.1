namespace AdventureLandWebapp.Models
{
    public class GUEST_REC
    {
        public int ID { get; set; }
        public int GuestID { get; set; }
        public int TicketID { get; set; }
        public DateTime Arrived { get; set; }
        public DateTime Departed { get; set; }
    }
}
