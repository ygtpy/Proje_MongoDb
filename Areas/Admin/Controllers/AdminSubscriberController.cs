using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSubscriberController : Controller
    {
        private readonly ISubscriberService _subscriberService;

        public AdminSubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _subscriberService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteSubscriber(string id)
        {
            await _subscriberService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubscriber(string id)
        {
            var value = await _subscriberService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto updateSubscriberDto)
        {
            await _subscriberService.UpdateAsync(updateSubscriberDto);
            return RedirectToAction("Index");
        }
    }
}
