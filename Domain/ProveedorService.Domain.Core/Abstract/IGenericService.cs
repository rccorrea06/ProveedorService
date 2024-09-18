namespace ProveedorService.Domain.Core.Abstract
{
    using MongoDB.Bson;
    public interface IGenericService
    {
        Task<T> GetById<T>(ObjectId Id);
    }
}
