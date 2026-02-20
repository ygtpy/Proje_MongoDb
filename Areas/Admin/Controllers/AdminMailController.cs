using AkademiQMongoDb.DTOs.MailDtos;
using AkademiQMongoDb.Services.MailServices;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly ISubscriberService _subscriberService;

        public AdminMailController(IMailService mailService, ISubscriberService subscriberService)
        {
            _mailService = mailService;
            _subscriberService = subscriberService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new MailRequestDto());
        }

        [HttpPost]
        public async Task<IActionResult> SendDiscountEmail(MailRequestDto mailRequestDto)
        {
            if (mailRequestDto == null || string.IsNullOrWhiteSpace(mailRequestDto.Subject) || string.IsNullOrWhiteSpace(mailRequestDto.Body))
            {
                ViewBag.Message = "Lütfen konu ve içerik alanlarını doldurunuz.";
                return View("Index", mailRequestDto ?? new MailRequestDto());
            }

            var subscribers = await _subscriberService.GetAllAsync();
            
            foreach (var subscriber in subscribers)
            {
                if (!string.IsNullOrWhiteSpace(subscriber.Email))
                {
                    await _mailService.SendEmailAsync(subscriber.Email, mailRequestDto.Subject, mailRequestDto.Body);
                }
            }

            ViewBag.Message = $"Toplam {subscribers.Count} aboneye mail başarıyla gönderildi.";
            return View("Index", new MailRequestDto());
        }
    }
}
