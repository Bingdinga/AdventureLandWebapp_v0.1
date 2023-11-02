namespace AdventureLandWebapp.Models
{
    public class ATTRACTION
    {
        public int AttractionID { get; set; }
        public string AttractionName { get; set;}
        public int Capacity { get; set;}
        public DateTime Open_Time { get; set; }
        public DateTime Close_Time { get; set;}
        public DateTime Last_Maintained { get; set; }
        public int Height_Req_Inches { get; set; }
        public int Age_Req {  get; set; }
    }
}
