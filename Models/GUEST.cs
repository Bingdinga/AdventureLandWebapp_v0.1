using System.ComponentModel.DataAnnotations;

namespace AdventureLandWebapp.Models
{
    public class GUEST
    {
        public int GuestID { get; set; }

        [Display(Name = "First")]
        public string FName { get; set; }

        [Display(Name = "Last")]
        public string LName { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }
        public int Height { get; set; }
    }
}
