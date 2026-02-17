using AkademiQMongoDb.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultFeatureViewComponent : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public DefaultFeatureViewComponent(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllAsync();
            return View(values);
        }
    }
}
