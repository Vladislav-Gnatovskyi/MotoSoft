namespace MotoSoft.Pages.ActiveListings
{
    public class ActiveListingsModel
    {
        public ActiveListingsModel() { }
        public ActiveListingsModel(string item_id, string custom_label, double qty, double price, string start_time, string listing_type, string title, string url)
        {
            ItemId = item_id;
            CustomLabel = custom_label;
            Quantity = qty;
            Price = price;
            StartTime = start_time;
            ListingType = listing_type;
            Title = title;
            Url = url;
        }
        public string ItemId { get; set; } = "";
        public string CustomLabel { get; set; } = "";
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string StartTime { get; set; } = "";
        public string ListingType { get; set; } = "";
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
    }
}
