using AkademiQMongoDb.DTOs.MessageDtos;
using AkademiQMongoDb.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _messageService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _messageService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DetailMessage(string id)
        {
             var value = await _messageService.GetByIdAsync(id);
             return View(value);
        }
    }
}
