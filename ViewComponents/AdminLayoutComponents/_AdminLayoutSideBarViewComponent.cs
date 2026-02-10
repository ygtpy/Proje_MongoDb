using AkademiQMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutSideBarViewComponent(IAdminService adminService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                ViewBag.fullName = "Kullanıcı";
                return View();
            }

            var admin = await adminService.GetAdminByUserNameAsync(userName);
            ViewBag.fullName = string.Join(" ", admin.FirstName, admin.LastName);
            return View();
        }
    }
}
