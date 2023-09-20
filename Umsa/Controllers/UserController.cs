using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umsa.DTOs;
using Umsa.Infraestructure;
using Umsa.Models;
using Umsa.Services;

namespace Umsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, users);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (await _unitOfWork.UserRepository.UserExist(dto.Email)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el mail: {dto.Email}");
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RegisterDTO dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));

            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el usuario");

            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Usuario actualizado con exito!");
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.Delete(id);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el usuario");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Usuario eliminado con exito!");
        }

      
    }
}
