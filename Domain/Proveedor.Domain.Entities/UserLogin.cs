namespace Proveedor.Domain.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class UserLogin
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
