using AkademiQMongoDb.DTOs.BasketDtos;
using AkademiQMongoDb.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            // Assuming Table ID 1 for now (can be dynamic later)
            var values = await _basketService.GetBasketDtoByMenuTableId(1);
            return View(values);
        }

        public async Task<IActionResult> AddToBasket(string productId)
        {
            var createBasketItemDto = new CreateBasketItemDto
            {
                ProductId = productId
            };
            await _basketService.AddBasketItem(createBasketItemDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBasketItem(string productId)
        {
            await _basketService.DeleteBasketItem(productId);
            return RedirectToAction("Index");
        }
    }
}
