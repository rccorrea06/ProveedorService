namespace ProveedorService.Domain.Core.IBusiness
{
    using ProveedorService.Domain.Core.Abstract;
    using ProveedorService.Domain.Dto;
    using ProveedorService.Domain.Utility.Utilities;

    public interface IProveedorBusiness : IProveedorService
    {
        Task<ResultResponse<string>> CreateAsync(CreateProveedorDto proveedorDto);
        Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetAllAsync();
        Task<ResultResponse<bool>> UpdateAsync(ActualizarProveedorDto proveedorDto);
    }
}
