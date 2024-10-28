using System.Collections.Generic;
using System.Threading.Tasks;
using PeikkoDesigner.Models;

namespace PeikkoDesigner.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserDto?>> GetAllUsersAsync();
		Task<UserDto?> GetUserByIdAsync(int id);
	}
}
