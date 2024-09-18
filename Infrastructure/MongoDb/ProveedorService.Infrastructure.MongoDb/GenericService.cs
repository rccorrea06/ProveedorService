using MongoDB.Bson;
using ProveedorService.Domain.Core.Abstract;

namespace ProveedorService.Infrastructure.MongoDb
{
    public class GenericService
    {
        private readonly AppDbContext _Context;

        public GenericService(AppDbContext context)
        {
            _Context = context;
        }

      
    }
}
