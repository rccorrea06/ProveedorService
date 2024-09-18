/**
<summary>
Controlador encargado para la gestión de los proveedores
</summary>
 */
namespace ProveedorService.Application.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProveedorService.Domain.Core.IBusiness;
    using ProveedorService.Domain.Dto;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorBusiness _Proveedor;

        public ProveedorController(IProveedorBusiness proveedor)
        {
            _Proveedor = proveedor;
        }

        /// <summary>
        /// Servicio Para consultar Proveedor por Id
        /// </summary>
        /// <param name="Id">ID del proveedor</param>
        /// <returns>Entidad con los datos registrados del proveedor</returns>
        [Authorize]
        [HttpGet("GetProveedorByIdAsync/{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            try
            {
                var result = await _Proveedor.GetByIdAsync(Id);
                var codeHttp = result.Error ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
                return StatusCode((int)codeHttp, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Servicio para consultar todos los proveedores
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _Proveedor.GetAllAsync();
                var codeHttp = result.Error ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
                return StatusCode((int)codeHttp, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Servicio para la creacion de los proveedores
        /// </summary>
        /// <param name="proveedorDto">Dto con la información requerida para la creación de un proveedor</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("CrearProveedorAsync")]
        public async Task<IActionResult> CreateProveedorAsync([FromBody] CreateProveedorDto proveedorDto)
        {
            try
            {
                var result = await _Proveedor.CreateAsync(proveedorDto);
                var codeHttp = result.Error ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
                return StatusCode((int)codeHttp, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Servicio para la actualización del proveedor
        /// </summary>
        /// <param name="proveedorDto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("ActualizarProveedorAsync")]
        public async Task<IActionResult> ActualizarProveedorAsync([FromBody] ActualizarProveedorDto proveedorDto)
        {
            try
            {
                var result = await _Proveedor.UpdateAsync(proveedorDto);
                var codeHttp = result.Error ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
                return StatusCode((int)codeHttp, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}