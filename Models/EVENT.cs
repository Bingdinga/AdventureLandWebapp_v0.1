namespace AdventureLandWebapp.Models
{
    public class EVENT
    {
        public int VenueID { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime Event_Started { get; set; }
        public DateTime Event_Ended { get; set;}
    }
}
