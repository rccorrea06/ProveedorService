using ProveedorService.Domain.Utility.Utilities;

namespace ProveedorService.Domain.Core.Abstract
{
    public interface IProveedorService
    {
         /// <summary>
         /// Method to get Provider by Id
         /// </summary>
         /// <param name="Id">Id from Provider</param>
         /// <returns></returns>
        Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetByIdAsync(string Id);
        
        /// <summary>
        /// Method to get all Providers
        /// </summary>
        /// <returns></returns>
        Task<ResultResponse<Proveedor.Domain.Entities.Proveedor>> GetAllAsync();

        /// <summary>
        /// Method to create Provider
        /// </summary>
        /// <param name="proveedor">Entity from Provider</param>
        /// <returns>Id provider created</returns>
        Task<ResultResponse<string>> CreateAsync(Proveedor.Domain.Entities.Proveedor proveedor);

        /// <summary>
        /// Method to update provider
        /// </summary>
        /// <param name="proveedor">Entity whit data to update</param>
        /// <returns>true if was update or false if it had wrong</returns>
        Task<ResultResponse<bool>> UpdateAsync(Proveedor.Domain.Entities.Proveedor proveedor);
    }
}
