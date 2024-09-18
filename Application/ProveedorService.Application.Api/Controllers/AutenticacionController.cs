namespace ProveedorService.Application.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Proveedor.Domain.Entities;
    using ProveedorService.Domain.Core.IBusiness;

    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAutenticacionBusines _Autenticacion;

        public AutenticacionController(IAutenticacionBusines autenticacion)
        {
            _Autenticacion = autenticacion;
        }

        [HttpPost("login")]
        public IActionResult Login([FromQuery] UserLogin userLogin)
        {
            var token = _Autenticacion.GenerateJwtToken(userLogin);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
