using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
