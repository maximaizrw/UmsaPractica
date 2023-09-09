using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umsa.Models;

namespace Umsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok();
        }
    }
}
