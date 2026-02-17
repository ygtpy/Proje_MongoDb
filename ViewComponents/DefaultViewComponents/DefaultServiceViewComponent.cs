using AkademiQMongoDb.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultServiceViewComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public DefaultServiceViewComponent(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceService.GetAllAsync();
            return View(values);
        }
    }
}
