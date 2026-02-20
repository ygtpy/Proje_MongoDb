using AkademiQMongoDb.DTOs.BasketDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IMongoCollection<Basket> _basketCollection;
        private readonly IMongoCollection<Product> _productCollection;

        public BasketService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _basketCollection = database.GetCollection<Basket>(databaseSettings.BasketCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task AddBasketItem(CreateBasketItemDto createBasketItemDto)
        {
            var product = await _productCollection.Find(x => x.Id == createBasketItemDto.ProductId).FirstOrDefaultAsync();
            var basket = await _basketCollection.Find(x => x.MenuTableId == 1).FirstOrDefaultAsync();

            if (basket == null)
            {
                basket = new Basket
                {
                    MenuTableId = 1,
                    BasketItems = new List<BasketItem>(),
                    TotalPrice = 0,
                    CreatedDate = DateTime.Now
                };
                await _basketCollection.InsertOneAsync(basket);
            }

            var existingItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == createBasketItemDto.ProductId);
            if (existingItem != null)
            {
                existingItem.Count++;
            }
            else
            {
                basket.BasketItems.Add(new BasketItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Count = 1,
                    ImageUrl = product.ImageUrl
                });
            }

            basket.TotalPrice = basket.BasketItems.Sum(x => x.Price * x.Count);
            basket.UpdatedDate = DateTime.Now;
            
            await _basketCollection.ReplaceOneAsync(x => x.MenuTableId == 1, basket);
        }

        public async Task DeleteBasketItem(string productId)
        {
            var basket = await _basketCollection.Find(x => x.MenuTableId == 1).FirstOrDefaultAsync();
            if (basket != null)
            {
                var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
                if (item != null)
                {
                    if (item.Count > 1)
                    {
                        item.Count--;
                    }
                    else
                    {
                        basket.BasketItems.Remove(item);
                    }
                    basket.TotalPrice = basket.BasketItems.Sum(x => x.Price * x.Count);
                    basket.UpdatedDate = DateTime.Now;
                    await _basketCollection.ReplaceOneAsync(x => x.MenuTableId == 1, basket);
                }
            }
        }

        public async Task<Basket> GetBasketByMenuTableId(int id)
        {
            return await _basketCollection.Find(x => x.MenuTableId == id).FirstOrDefaultAsync();
        }

        public async Task<ResultBasketDto> GetBasketDtoByMenuTableId(int id)
        {
            var basket = await _basketCollection.Find(x => x.MenuTableId == id).FirstOrDefaultAsync();
            if (basket == null)
            {
                return new ResultBasketDto
                {
                    MenuTableId = id,
                    BasketItems = new List<BasketItem>(),
                    TotalPrice = 0
                };
            }
            return new ResultBasketDto
            {
                Id = basket.Id,
                MenuTableId = basket.MenuTableId,
                TotalPrice = basket.TotalPrice,
                BasketItems = basket.BasketItems
            };
        }
    }
}
