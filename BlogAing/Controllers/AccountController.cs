using BlogAing.Data;
using BlogAing.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogAing.Controllers
{
    public class AccountController : Controller
    {
        private readonly MySqlContext _context;
        public AccountController(MySqlContext c)
        {
            _context = c;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Login data)
        {
            var user = _context.Users
                .Where(x => x.Username == data.Username && x.Password == data.Password)
                .FirstOrDefault();

            if(user != null)
            {
                //data user yg sedang login
                var Claims = new List<Claim>()
                {
                    new Claim("username", user.Username),
                    new Claim("name", user.Fullname),
                    new Claim("role", "Admin")
                };

                var Identity = new ClaimsIdentity(Claims, "Cookie", "name", "role");
                var principal = new ClaimsPrincipal(Identity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/user/index");
            }
            return View();
        }
    }
}
