using System.ComponentModel.DataAnnotations;

namespace AdventureLandWebapp.Models
{
    public class SHOP
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Location { get; set; }
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }
    }
}
