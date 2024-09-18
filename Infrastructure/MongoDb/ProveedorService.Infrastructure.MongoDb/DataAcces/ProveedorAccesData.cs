namespace ProveedorService.Infrastructure.MongoDb.DataAcces
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;
    using MongoDB.Bson;
    using ProveedorService.Domain.Core.Abstract;
    using ProveedorService.Domain.Utility.Utilities;
    using System.Collections.ObjectModel;

    public class ProveedorAccesData : IProveedorService
    {
        private readonly AppDbContext _Context;

        public ProveedorAccesData(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<ResultResponse<string>> CreateAsync(Proveedor.Domain.Entities.Proveedor proveedor)
        {
            try
            {
                proveedor.Id = ObjectId.GenerateNewId().ToString();
                await _Context.AddAsync(proveedor);
                await _Context.SaveChangesAsync();

                return new ResultResponse<string>
                {
                    ResultData = new()
                    {
                        proveedor.Id.ToString()
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResultResponse<string>
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetAllAsync()
        {
            try
            {
                var result = await _Context.Set<Proveedor.Domain.Entities.Proveedor>().ToListAsync<Proveedor.Domain.Entities.Proveedor>();
                return new ResultResponse<Proveedor.Domain.Entities.Proveedor>()
                {
                    ResultData = new Collection<Proveedor.Domain.Entities.Proveedor>(result)
                };
            }
            catch (Exception ex)
            {
                return new ResultResponse<Proveedor.Domain.Entities.Proveedor>
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetByIdAsync(string Id)
        {
            try
            {
                var result = await _Context.Set<Proveedor.Domain.Entities.Proveedor>().FindAsync(Id);
                return new ResultResponse<Proveedor.Domain.Entities.Proveedor>
                {
                    ResultData = new()
                  {
                      result
                  }
                };
            }
            catch (Exception ex)
            {
                return new ResultResponse<Proveedor.Domain.Entities.Proveedor>
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResultResponse<bool>> UpdateAsync(Proveedor.Domain.Entities.Proveedor proveedor)
        {
            try
            {
                _Context.Proveedores.Update(proveedor);
                await _Context.SaveChangesAsync();
                return new ResultResponse<bool>
                {
                    ResultData = new System.Collections.ObjectModel.Collection<bool>
                    {
                        true
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResultResponse<bool>
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }
    }
}
