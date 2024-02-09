using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Implementation;
using ConversorAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionServices _subscriptionServices;
        public SubscriptionController(ISubscriptionServices subscriptionServices)
        {
            _subscriptionServices = subscriptionServices;
        }

        [HttpGet]
        public IActionResult GetAllSubs()
        {
            return Ok(_subscriptionServices.GetAll());
        }

        [HttpGet("Id")]
        public IActionResult GetSubById(int id)
        {
            return Ok(_subscriptionServices.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateSubs(CreateOrUpdateSubs dto)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                try
                {
                    _subscriptionServices.Create(dto);
                    return Created("Created", dto.Name);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized();
        }

        [HttpPut("Id")]
        public IActionResult UpdateSubs(CreateOrUpdateSubs dto, int id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
                if (role == "Admin")
                {
                    if (!_subscriptionServices.CheckIfSubExists(id))
                    {
                        return NotFound();
                    }
                    _subscriptionServices.Update(dto, id);
                    return NoContent();
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Id")]
        public IActionResult DeleteSubs(int id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                _subscriptionServices.Delete(id);
                return Ok(id);
            }
            return Unauthorized();
        }
    }
}
