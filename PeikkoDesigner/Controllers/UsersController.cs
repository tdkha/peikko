using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeikkoDesigner.Models;
using PeikkoDesigner.Services;

namespace PeikkoDesigner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //private readonly IUserService _userService;

        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}


        // Define your API endpoints here...
        private readonly PeikkoContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Include(u => u.Roles).ToListAsync();
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}