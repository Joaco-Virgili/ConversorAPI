using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Implementation;
using ConversorAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ConversorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyServices _currencyServices;
        public CurrencyController(ICurrencyServices currencyServices)
        {
            _currencyServices = currencyServices;
        }

        [HttpGet]

        public IActionResult GetAllCurrency() 
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                return Ok(_currencyServices.GetAll());
            }
            return Unauthorized();
        }

        [HttpGet("Id")]

        public IActionResult GetOneById(int id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                return Ok(_currencyServices.GetById(id));
            }
            return Unauthorized();
        }

        [HttpPost]
        public IActionResult CreateCurrency(CreateOrUpdateCurrency dto)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                    try
                    {
                        _currencyServices.Create(dto);
                        return Created("Created", dto.Name);
                    }
                    catch(Exception ex)
                    {
                        return BadRequest(ex.Message);
                    } 
            }
            return Unauthorized();
        }

        [HttpPut("Id")]
        public IActionResult UpdateCurrency(CreateOrUpdateCurrency dto, int id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
                if (role == "Admin")
                {
                    if (!_currencyServices.CheckIfCurrencyExists(id))
                    {
                        return NotFound();
                    }
                    _currencyServices.Update(dto, id);
                    return NoContent();
                }
                return Unauthorized();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCurrency(int id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                _currencyServices.Delete(id);
                return Ok(id);
            }
            return Unauthorized();
        }
    }
}
