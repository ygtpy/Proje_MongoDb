using AkademiQMongoDb.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultBannerViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public DefaultBannerViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bannerService.GetAllAsync();
            return View(values);
        }
    }
}
