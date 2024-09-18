using System.ComponentModel.DataAnnotations;

namespace ProveedorService.Domain.Dto
{
    public class CreateProveedorDto
    {
        [Required(ErrorMessage = "El nit es requedio")]
        public string? Nit { get; set; }

        [Required(ErrorMessage = "Razon Social es requeida")]
        public string? RazonSocial { get; set; }

        [Required(ErrorMessage = "La Dirección es requerida")]
        public string? Direccion { get; set; }
        
        [Required(ErrorMessage = "El correo es requerida")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El Departamento es requerido")]
        public string? Departamento { get; set; }

        [Required(ErrorMessage = "La Ciudad es requerida")]
        public string? Ciudad { get; set; }

        public bool Activo { get; set; } = true;

        [Required(ErrorMessage = "El nombre del contacto es requerido")]
        public string? NombreContacto { get; set; }

        [Required(ErrorMessage = "El correo del contato es requerido")]
        [EmailAddress]
        public string? CorreoContacto { get; set; }
    }
}