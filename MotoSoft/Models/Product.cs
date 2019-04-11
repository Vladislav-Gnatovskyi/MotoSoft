namespace MotoSoft.Models
{
    class Product
    {
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string MPN { get; set; }
    }
}
