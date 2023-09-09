using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umsa.DTOs;

namespace Umsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <param name="todos"> 
        /// <returns>Todos los usuarios o devuelve un usuario</returns>
        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios (bool todos)
        {
            try
            {
                if (todos)
                {
                    return Ok("Todos los usuarios");
                }
                else
                {
                    return Ok("Un usuario");
                }
            }
            catch (Exception)
            {

                return Ok("Contacte a sistemas");
            }
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            if (login.Usuario == "maxi" && login.Clave == "maxi") {
            return Ok("Bienvenido");
                }
            else
            {
                return Unauthorized("Usuario o clave incorrectos");
            }
        }
    }
}
