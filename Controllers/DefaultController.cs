using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly ISubscriberService _subscriberService;

        public DefaultController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto createSubscriberDto)
        {
            await _subscriberService.CreateAsync(createSubscriberDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
