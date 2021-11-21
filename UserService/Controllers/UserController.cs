using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserService.Core;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserProcessor _processor;

        public UserController(IUserProcessor processor)
        {
            _processor = processor;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<User>> SaveUser(User user, CancellationToken cancellationToken)
        {
            var savedUser = await _processor.SaveUser(user, cancellationToken);

            if (savedUser is null)
            {
                return BadRequest();
            }

            return savedUser;
        }

        [Route("{userId}")]
        [HttpGet]
        public async Task<ActionResult<User>> FetchUser(string userId, CancellationToken cancellationToken)
        {
            var user = await _processor.FetchUser(userId, cancellationToken);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }
    }
}