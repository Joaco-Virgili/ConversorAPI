using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                return Ok(_userServices.GetAll());
            }
            return Unauthorized();
        }

        [HttpGet("Id")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                return Ok(_userServices.GetById(id));
            }
            return Unauthorized();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(CreateOrUpdateUser dto)
        {
            try
            {
                _userServices.Create(dto);
                return Created("Created", dto.Email);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateUser(CreateOrUpdateUser dto, int Id)
        {
            if (!_userServices.CheckIfUserExists(Id))
            {
                return NotFound();
            }
            try
            {
                _userServices.Update(dto, Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpPut("SubscriptionId")]
        [Authorize]
        public IActionResult ChangeSubscription(ChangeUserSubDto dto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);

            if (!_userServices.CheckIfUserExists(userId))
            {
                return NotFound();
            }

            try
            {
                if (dto.subscriptionId >= 1 && dto.subscriptionId <= 3)
                {
                    _userServices.ChangeSub(dto, userId);
                    return Ok(dto);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteUser(int id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if(role == "Admin")
            {
                _userServices.Delete(id);
                return Ok();
            }
            return Unauthorized();
        }
    }
}
