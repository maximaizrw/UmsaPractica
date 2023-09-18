using Microsoft.AspNetCore.Mvc;
using Umsa.DTOs;
using Umsa.Helpers;
using Umsa.Services;

namespace Umsa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration )
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDTO dto)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);
            if (userCredentials is null) return Unauthorized("Credenciales incorrectas");

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UserLoginDTO()
            {
                Email = userCredentials.Email,
                FirstName = userCredentials.FirstName,
                LastName = userCredentials.LastName,
                Token = token
            };

            return Ok(user);
        }
        
    }
}
