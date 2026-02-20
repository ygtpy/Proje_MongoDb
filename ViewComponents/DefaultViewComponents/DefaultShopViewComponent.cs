using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultShopViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public DefaultShopViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllAsync();
            // Could filter by "Popular" if that field existed, or take top 8
            var popularProducts = values.Take(8).ToList();
            return View(popularProducts);
        }
    }
}
