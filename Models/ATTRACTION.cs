namespace AdventureLandWebapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ATTRACTION
    {
        public int AttractionID { get; set; }
        [Display(Name = "Name")]
        public string AttractionName { get; set;}

        public int Capacity { get; set;}

        [Display(Name = "Opens")]
        [DataType(DataType.Time)]
        public DateTime Open_Time { get; set; }

        [Display(Name = "Closes")]
        [DataType(DataType.Time)]
        public DateTime Close_Time { get; set;}

        [Display(Name = "Last Maintained")]
        [DataType(DataType.Date)]
        public DateTime Last_Maintained { get; set; }

        [Display(Name = "Height Requirement (Inches)")]
        public int Height_Req_Inches { get; set; }

        [Display(Name = "Age Requirement")]

        public int Age_Req {  get; set; }
    }
}
