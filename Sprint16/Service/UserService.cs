using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Service
{
    public class UserService : IUserService
    {
        private readonly ShoppingContext _dbContext;
        public UserService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task UpdateUserCategory(int userId, BuyerCategory category)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user._BuyerType.Category = category;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
