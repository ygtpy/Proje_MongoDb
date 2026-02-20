using AkademiQMongoDb.DTOs.BasketDtos;
using AkademiQMongoDb.Entities;

namespace AkademiQMongoDb.Services.BasketServices
{
    public interface IBasketService
    {
        Task<Basket> GetBasketByMenuTableId(int id);
        Task AddBasketItem(CreateBasketItemDto createBasketItemDto);
        Task DeleteBasketItem(string productId);
        Task<ResultBasketDto> GetBasketDtoByMenuTableId(int id);
    }
}
