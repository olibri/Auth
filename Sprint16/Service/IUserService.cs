using Sprint16.Models;

namespace Sprint16.Service
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        Task UpdateUserCategory(int userId, BuyerCategory category);

    }
}
