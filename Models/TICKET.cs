namespace AdventureLandWebapp.Models
{
    public class TICKET
    {
        public int TicketID { get; set; }
        public DateTime Purchase_Date { get; set; }
        public int Ticket_Type { get; set; }
        public int GuestID { get; set; }
        public DateTime Valid_Through {  get; set; }
    }
}
