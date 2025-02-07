using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Models;
using System.Security.Claims;

namespace Practic.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(a => a.Login == account.Login);
            if (user != null)
            { 
                if (user.Password == account.Password) {
                    var claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, account.Login) };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                }
            }
            return RedirectToAction("Index", "Partners");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
