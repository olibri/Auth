using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.ViewModels;
using System.Security.Claims;

namespace Sprint16.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private ShoppingContext db;
        
        public AccountController(ShoppingContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User? user = await db.Users
                    .Include(u=>u.Role)
                    .FirstOrDefaultAsync(u=> u.Email == loginViewModel.Email /*&& u.Password == loginViewModel.Password*/);

                if (user != null && BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.Password))
                {
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Incorrect login and(or) password");
            }
            return View(loginViewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register registerViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(us=> us.Email == registerViewModel.Email);
                if (user == null)
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerViewModel.Password);

                    user = new User { Email = registerViewModel.Email , Password = hashedPassword};
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");

                    
                    if (userRole != null)
                    {
                        user.Role = userRole;
                    }
                    db.Users.Add(user);                          

                    await db.SaveChangesAsync();
                    await Authenticate(user);
                    return RedirectToAction(nameof(Index), "Home");   
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login and(or) password");
                }
            }
            return View(registerViewModel);
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
                new Claim("buyerCategory", user._BuyerType.Category.ToString())
            };
            ClaimsIdentity Id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(Id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login), "Account");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
