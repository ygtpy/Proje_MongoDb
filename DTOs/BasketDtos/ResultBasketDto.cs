using AkademiQMongoDb.Entities;

namespace AkademiQMongoDb.DTOs.BasketDtos
{
    public class ResultBasketDto
    {
        public string Id { get; set; } = string.Empty;
        public int MenuTableId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
