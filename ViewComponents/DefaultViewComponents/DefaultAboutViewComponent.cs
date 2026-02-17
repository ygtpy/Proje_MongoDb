using AkademiQMongoDb.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultAboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public DefaultAboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAsync();
            return View(values);
        }
    }
}
