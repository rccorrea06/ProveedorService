namespace ProveedorService.Domain.Core.Business
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Proveedor.Domain.Entities;
    using ProveedorService.Domain.Core.IBusiness;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    public class AutenticacionBusines : IAutenticacionBusines
    {
        private readonly IConfiguration _Configuration;

        public AutenticacionBusines(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string GenerateJwtToken(UserLogin userLogin)
        {

            if (userLogin != null && (userLogin.Username != _Configuration["Jwt:UserToken"] || userLogin.Password != _Configuration["Jwt:PasswprToken"]))
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_Configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_Configuration["Jwt:DurationInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
