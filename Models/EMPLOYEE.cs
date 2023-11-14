using System.ComponentModel.DataAnnotations;

namespace AdventureLandWebapp.Models
{
    public class EMPLOYEE
    {
        public int EmployeeID { get; set; }
        public int SSN { get; set; }
        public int SuperID { get; set; }
        public int Role { get; set; }
        public int Auth_Level { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }
        public DateTime DOB { get; set; }
        public decimal Salary { get; set; }
        public decimal Hourly_Wage { get; set; }
    }
}
