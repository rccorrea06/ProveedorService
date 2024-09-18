using Proveedor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorService.Domain.Core.IBusiness
{
    public interface IAutenticacionBusines
    {
        string GenerateJwtToken(UserLogin userLogin);
    }
}
