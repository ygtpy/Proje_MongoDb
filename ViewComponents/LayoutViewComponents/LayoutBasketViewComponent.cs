using AkademiQMongoDb.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.LayoutViewComponents
{
    public class LayoutBasketViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public LayoutBasketViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasketDtoByMenuTableId(1);
            return View(values);
        }
    }
}
