using AkademiQMongoDb.DTOs.CategoryDtos;
using AkademiQMongoDb.DTOs.ProductDtos;
using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultProductViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public DefaultProductViewComponent(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            
            // Return tuple
            return View((categories, products));
        }
    }
}
