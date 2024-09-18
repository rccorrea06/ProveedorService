namespace ProveedorServices.Domain.UniteTest.Aplication.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using ProveedorService.Application.Api.Controllers;
    using ProveedorService.Domain.Core.IBusiness;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    [TestClass]
    public class ProveedorControllerTest
    {

        /// <summary>
        /// Test Method para validar respues succes al consultar un proveedor por Id
        /// </summary>
        /// <returns>Succes si no retorna error</returns>
        [TestMethod]
        public async Task GetOk()
        {
            var resultPro = new ProveedorService.Domain.Utility.Utilities.ResultResponse<Proveedor.Domain.Entities.Proveedor>()
            {
                Error = false,
                ResultData = new System.Collections.ObjectModel.Collection<Proveedor.Domain.Entities.Proveedor>
                {
                    new Proveedor.Domain.Entities.Proveedor
                    {
                        Activo = true,
                        Nit = "12345678",
                    }
                }
            };

            var proveedorBusinessMock = new Mock<IProveedorBusiness>();
            proveedorBusinessMock.Setup(p => p.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(resultPro);

            var proveedorController = new ProveedorController(proveedorBusinessMock.Object);

            var result = await proveedorController.Get("123456789");

            Assert.IsTrue((result as ObjectResult).StatusCode == (int)HttpStatusCode.OK);

        }

        /// <summary>
        /// Test Method para validar respues succes al consultar un proveedor por Id
        /// </summary>
        /// <returns>Succes si no retorna error</returns>
        [TestMethod]
        public async Task GetByIdError()
        {
            var resultPro = new ProveedorService.Domain.Utility.Utilities.ResultResponse<Proveedor.Domain.Entities.Proveedor>()
            {
                Error = false,
                ResultData = new System.Collections.ObjectModel.Collection<Proveedor.Domain.Entities.Proveedor>
                {
                    new Proveedor.Domain.Entities.Proveedor
                    {
                        Activo = true,
                        Nit = "12345678",
                    }
                }
            };

            var proveedorBusinessMock = new Mock<IProveedorBusiness>();
            proveedorBusinessMock.Setup(p => p.GetByIdAsync(It.IsAny<string>())).ThrowsAsync(new NullReferenceException());

            var proveedorController = new ProveedorController(proveedorBusinessMock.Object);

            var result = await proveedorController.Get("123456789");

            Assert.IsTrue((result as ObjectResult).StatusCode == (int)HttpStatusCode.BadRequest);

        }


        [TestMethod]
        public async Task GetAllOk()
        {
            var listProveedores = new List<Proveedor.Domain.Entities.Proveedor>
                    {
                        new Proveedor.Domain.Entities.Proveedor
                        {
                            Activo = true,
                            Nit = "12345678",
                        },
                        new Proveedor.Domain.Entities.Proveedor
                        {
                            Activo = true,
                            Nit = "23423",
                        }
                    };

            var resultPro = new ProveedorService.Domain.Utility.Utilities.ResultResponse<Proveedor.Domain.Entities.Proveedor>()
            {
                Error = false,
                ResultData = new System.Collections.ObjectModel.Collection<Proveedor.Domain.Entities.Proveedor>(listProveedores)
            };

            var proveedorBusinessMock = new Mock<IProveedorBusiness>();
            proveedorBusinessMock.Setup(p => p.GetAllAsync()).ReturnsAsync(resultPro);

            var proveedorController = new ProveedorController(proveedorBusinessMock.Object);

            var result = await proveedorController.GetAllAsync();

            Assert.IsTrue((result as ObjectResult).StatusCode == (int)HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task GetAllError()
        {
            var resultPro = new ProveedorService.Domain.Utility.Utilities.ResultResponse<Proveedor.Domain.Entities.Proveedor>()
            {
                Error = false,
                ResultData = new System.Collections.ObjectModel.Collection<Proveedor.Domain.Entities.Proveedor>
                {
                    new Proveedor.Domain.Entities.Proveedor
                    {
                        Activo = true,
                        Nit = "12345678",
                    }
                }
            };

            var proveedorBusinessMock = new Mock<IProveedorBusiness>();
            proveedorBusinessMock.Setup(p => p.GetAllAsync()).ThrowsAsync(new NullReferenceException());

            var proveedorController = new ProveedorController(proveedorBusinessMock.Object);

            var result = await proveedorController.GetAllAsync();

            Assert.IsTrue((result as ObjectResult).StatusCode == (int)HttpStatusCode.BadRequest);

        }

    }
}
