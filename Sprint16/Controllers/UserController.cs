using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sprint16.Models;
using Sprint16.Service;
using Sprint16.ViewModels;

namespace Sprint16.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult AssignCategory()
        {
            var users = _userService.GetAllUsers();

            var model = new UserCategoryViewModel
            {

                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text =  u.UserName
                }),
                Categories = Enum.GetValues(typeof(BuyerCategory))
                .Cast<BuyerCategory>()
                .Select(b => new SelectListItem { Value = b.ToString(), Text = b.ToString() })

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AssignCategory(UserCategoryViewModel model) {
            if(ModelState.IsValid)
            {
                _userService.UpdateUserCategory(model.UserId, model.SelectedCategory);
                return RedirectToAction("Index", "Home");
            }
            
            return View(model);
        }
    }
}
