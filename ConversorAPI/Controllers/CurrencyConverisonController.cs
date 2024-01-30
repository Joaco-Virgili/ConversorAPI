
using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyConverisonController : ControllerBase
    {
        private readonly ICurrencyConverisonServices _currencyConverisonServices;
        public CurrencyConverisonController(ICurrencyConverisonServices currencyConverisonServices)
        {
            _currencyConverisonServices = currencyConverisonServices;
        }

        [HttpGet]
        public IActionResult GetAllConversionByUser()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            return Ok(_currencyConverisonServices.GetAllConversion(userId));
        }

        [HttpGet("Id")]
        public IActionResult GetOneById(int id)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            return Ok(_currencyConverisonServices.GetAllConversion(userId).Where(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult NewCurrencyConversion(CreateNewConversionDto dto)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
                var conversion = _currencyConverisonServices.Create(dto, userId);
                return Created("Created", conversion.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("count")]
        public IActionResult GetConversionsCount()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))!.Value;
            if (role == "Admin")
            {
                var conversion = _currencyConverisonServices.GetConversionsCount(userId);
                return Ok(conversion);
            }
            return Unauthorized();
        }
    }
}
