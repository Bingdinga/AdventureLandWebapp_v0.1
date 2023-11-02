namespace AdventureLandWebapp.Models
{
    public class MAINTENENCE_PERSONNEL_REC
    {
        public int Id { get; set; }
        public int Maint_RecID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime work_started { get; set; }
        public DateTime work_ended { get; set;}
    }
}
