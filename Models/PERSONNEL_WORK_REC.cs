namespace AdventureLandWebapp.Models
{
    public class PERSONNEL_WORK_REC
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public int VenueID { get; set; }
        public DateTime work_started { get; set; }
        public DateTime work_ended { get; set;}
    }
}
