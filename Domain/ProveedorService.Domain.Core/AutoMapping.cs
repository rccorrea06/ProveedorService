namespace ProveedorService.Domain.Core
{
    using AutoMapper;
    using ProveedorService.Domain.Dto;
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateProveedorDto, Proveedor.Domain.Entities.Proveedor>();
            CreateMap<ActualizarProveedorDto, Proveedor.Domain.Entities.Proveedor>();
        }
    }
}