using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Proveedor.Domain.Entities
{
    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Nit { get; set; }

        public string? RazonSocial { get; set; }

        public string? Direccion { get; set; }

        public string? Departamento { get; set; }

        public string? Ciudad { get; set; }

        public bool Activo { get; set; } = true;

        public string? NombreContacto { get; set; }

        public string? CorreoContacto { get; set; }
    }
}
