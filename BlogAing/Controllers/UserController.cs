using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogAing.Controllers
{
    //harus akses login
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            //
            var claim = HttpContext.User.Claims;
            var useFullname = claim.Where(x => x.Type == "name").FirstOrDefault()?.Value;

            ViewData["Fullname"] = useFullname;
            return View();
        }
    }
}
