using PeikkoDesigner.Models;
using Microsoft.EntityFrameworkCore;

namespace PeikkoDesigner.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        //Task<User> GetUserByIdAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly PeikkoContext _context;
        public UserService(PeikkoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
