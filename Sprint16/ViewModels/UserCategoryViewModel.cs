using Microsoft.AspNetCore.Mvc.Rendering;
using Sprint16.Models;

namespace Sprint16.ViewModels
{
    public class UserCategoryViewModel
    {
        public int UserId { get; set; }
        public IEnumerable<User> Users { get; set; }
        public int? SelectedBuyerTypeId {  get; set; }
        public IEnumerable<SelectListItem> BuyerTypes { get; set; }

        public string BuyerName {  get; set; }

    }
}
