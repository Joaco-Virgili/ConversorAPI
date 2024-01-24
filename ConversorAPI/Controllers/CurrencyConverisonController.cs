
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
    }
}
