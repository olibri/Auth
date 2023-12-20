using Microsoft.AspNetCore.Mvc.Rendering;
using Sprint16.Models;

namespace Sprint16.ViewModels
{
    public class UserCategoryViewModel
    {
        public int UserId { get; set; }
        public BuyerCategory SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}
