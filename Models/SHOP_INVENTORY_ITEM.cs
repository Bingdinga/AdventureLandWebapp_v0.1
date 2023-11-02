namespace AdventureLandWebapp.Models
{
    public class SHOP_INVENTORY_ITEM
    {
        public int Id { get; set; }
        public int ShopID { get; set; }
        public int ItemID { get; set; }
        public DateTime Stocked_On { get; set; }
        public DateTime Sold_On { get; set; }
    }
}
