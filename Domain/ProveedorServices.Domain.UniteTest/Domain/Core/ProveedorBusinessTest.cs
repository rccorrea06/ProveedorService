namespace ProveedorServices.Domain.UniteTest.Domain.Core
{
    using AutoMapper;
    using Moq;
    using ProveedorService.Domain.Core.Abstract;
    using ProveedorService.Domain.Core.Business;
    using ProveedorService.Domain.Dto;
    using ProveedorService.Domain.Utility.Utilities;

    [TestClass]
    public class ProveedorBusinessTest
    {
        [TestMethod]
        public async Task CreateAsyncOk()
        {
            var dataProveedor = new CreateProveedorDto()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<string>
            {
                Error = false,
                ResultData = new System.Collections.ObjectModel.Collection<string>
                {
                    "fasdfasdfasdfasdsd"
                }
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.CreateAsync(It.IsAny<Proveedor.Domain.Entities.Proveedor>())).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.CreateAsync(dataProveedor);

            Assert.IsFalse(result.Error);

        }

        [TestMethod]
        public async Task CreateAsyncError()
        {
            var dataProveedor = new CreateProveedorDto()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<string>
            {
                Error = true,
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.CreateAsync(It.IsAny<Proveedor.Domain.Entities.Proveedor>())).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.CreateAsync(dataProveedor);

            Assert.IsTrue(result.Error);

        }

        [TestMethod]
        public async Task GetAllAsyncOk()
        {
            var dataProveedor = new CreateProveedorDto()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<Proveedor.Domain.Entities.Proveedor>
            {
                Error = false,
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.GetAllAsync()).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.GetAllAsync();

            Assert.IsFalse(result.Error);

        }

        [TestMethod]
        public async Task GetAllAsyncError()
        {
            var dataProveedor = new CreateProveedorDto()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<Proveedor.Domain.Entities.Proveedor>
            {
                Error = true,
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.GetAllAsync()).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.GetAllAsync();

            Assert.IsTrue(result.Error);
        }

        [TestMethod]
        public async Task GetByIdAsyncOk()
        {
            var dataProveedor = new CreateProveedorDto()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<Proveedor.Domain.Entities.Proveedor>
            {
                Error = false,
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.GetByIdAsync("23423513452345234");

            Assert.IsFalse(result.Error);
        }

        [TestMethod]
        public async Task GetByIdAsyncError()
        {
            var dataProveedor = new CreateProveedorDto()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<Proveedor.Domain.Entities.Proveedor>
            {
                Error = true,
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.GetByIdAsync("3242342342342");

            Assert.IsTrue(result.Error);

        }

        [TestMethod]
        public async Task UpdateAsyncOk()
        {
            var dataProveedor = new Proveedor.Domain.Entities.Proveedor()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<bool>
            {
                Error = false,
                ResultData = new System.Collections.ObjectModel.Collection<bool> { true }
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.UpdateAsync(It.IsAny<Proveedor.Domain.Entities.Proveedor>())).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.UpdateAsync(dataProveedor);

            Assert.IsFalse(result.Error);
        }

        [TestMethod]
        public async Task UpdateAsyncError()
        {
            var dataProveedor = new Proveedor.Domain.Entities.Proveedor()
            {
                Activo = true,
                Ciudad = "Cartagena",
                Departamento = "Bolivar"
            };

            var resultMock = new ResultResponse<bool>
            {
                Error = true,
                ResultData = new System.Collections.ObjectModel.Collection<bool> { true }
            };

            var proveedorServiceMock = new Mock<IProveedorService>();
            var mapperMock = new Mock<IMapper>();

            proveedorServiceMock.Setup(p => p.UpdateAsync(It.IsAny<Proveedor.Domain.Entities.Proveedor>())).ReturnsAsync(resultMock);

            var proveedorBusiness = new ProveedorBusiness(proveedorServiceMock.Object, mapperMock.Object);

            var result = await proveedorBusiness.UpdateAsync(dataProveedor);

            Assert.IsTrue(result.Error);

        }

    }
}