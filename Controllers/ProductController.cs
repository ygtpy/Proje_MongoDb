using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
