using PeikkoDesigner.Models;
using Microsoft.EntityFrameworkCore;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public class UserService : IUserService
	{
		private readonly AppDbContext _context;
		public UserService(AppDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
		public async Task<IEnumerable<UserDto?>> GetAllUsersAsync()
		{
			return await _context.Users
				.Include(u => u.Roles)
				.Select(u => new UserDto
				{
					Id = u.Id,
					Username = u.Username,
					Roles = u.Roles.Select(r => r.Title).ToList()
				})
				.ToListAsync();
		}

		public async Task<UserDto?> GetUserByIdAsync(int id)
		{
			return await _context.Users
				.Where(u => u.Id == id)
				.Include(u => u.Roles)
				.Select(u => new UserDto
				{
					Id = u.Id,
					Username = u.Username,
					Roles = u.Roles.Select(r => r.Title).ToList()
				})
				.FirstOrDefaultAsync();
		}
	}
}
