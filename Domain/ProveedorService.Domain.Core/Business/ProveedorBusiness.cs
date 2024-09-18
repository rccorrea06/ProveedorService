namespace ProveedorService.Domain.Core.Business
{
    using AutoMapper;
    using ProveedorService.Domain.Core.Abstract;
    using ProveedorService.Domain.Core.IBusiness;
    using ProveedorService.Domain.Dto;
    using ProveedorService.Domain.Utility.Utilities;

    public class ProveedorBusiness : IProveedorBusiness
    {
        private readonly IProveedorService _ProvedorService;
        private readonly IMapper _Mapper;

        public ProveedorBusiness(IProveedorService provedorService, IMapper mapper)
        {
            _ProvedorService = provedorService;
            _Mapper = mapper;
        }

        public async Task<ResultResponse<string>> CreateAsync(CreateProveedorDto proveedorDto)
        {
            var proveedor = _Mapper.Map<Proveedor.Domain.Entities.Proveedor>(proveedorDto);

            return await this.CreateAsync(proveedor);
        }
        public async Task<ResultResponse<string>> CreateAsync(Proveedor.Domain.Entities.Proveedor proveedor)
        {
            return await _ProvedorService.CreateAsync(proveedor);
        }
        public async Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetAllAsync()
        {
            return await _ProvedorService.GetAllAsync();
        }

        public async Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetByIdAsync(string Id)
        {
            return await _ProvedorService.GetByIdAsync(Id);
        }
        public async Task<ResultResponse<bool>> UpdateAsync(Proveedor.Domain.Entities.Proveedor proveedor)
        {
            return await _ProvedorService.UpdateAsync(proveedor);
        }

        public async Task<ResultResponse<bool>> UpdateAsync(ActualizarProveedorDto proveedorDto)
        {
            var proveedor = _Mapper.Map<Proveedor.Domain.Entities.Proveedor>(proveedorDto);

            return await this.UpdateAsync(proveedor);
        }
    }
}