namespace AkademiQMongoDb.Entities
{
    public class BasketItem
    {
        public string ProductId { get; set; } = string.Empty;
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string? ImageUrl { get; set; }
    }
}
