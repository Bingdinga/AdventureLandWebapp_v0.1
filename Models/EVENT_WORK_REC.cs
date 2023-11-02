namespace AdventureLandWebapp.Models
{
    public class EVENT_WORK_REC
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public int EventID { get; set; }
        public DateTime Work_Started { get; set; }
        public DateTime Work_Completed { get; set;}
    }
}
