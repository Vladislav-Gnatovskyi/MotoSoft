namespace MotoSoft.Pages.ActiveListings
{
    public class ActiveListingsModel
    {
        public ActiveListingsModel() { }
        public ActiveListingsModel(string item_id, string custom_label, double qty, double price, string start_time, string listing_type, string title, string url)
        {
            ITEM_ID = item_id;
            CUSTOM_LABEL = custom_label;
            QTY = qty;
            PRICE = price;
            START_TIME = start_time;
            LISTING_TYPE = listing_type;
            TITLE = title;
            URL = url;
        }
        public string ITEM_ID { get; set; }
        public string CUSTOM_LABEL { get; set; }
        public double QTY { get; set; }
        public double PRICE { get; set; }
        public string START_TIME { get; set; }
        public string LISTING_TYPE { get; set; }
        public string TITLE { get; set; }
        public string URL { get; set; }
    }
}
