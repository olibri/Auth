using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.Service;
using Sprint16.ViewModels;

namespace Sprint16.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        ShoppingContext _db;
        public UserController(ShoppingContext shoppingContext)
        {
            _db = shoppingContext;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _db.Users.Include(u => u.BuyerType).ToListAsync();
            var buyerTypes = await _db.BuyerTypes.ToListAsync();

            var viewModel = new UserCategoryViewModel
            {
                Users = users,
                BuyerTypes = buyerTypes.Select(bt => new SelectListItem
                {
                    Value = bt.Id.ToString(),
                    Text = bt.BuyerName
                })
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int userId, int SelectedBuyerTypeId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                user.BuyerTypeId = SelectedBuyerTypeId;
                _db.Update(user);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    
    }
}
