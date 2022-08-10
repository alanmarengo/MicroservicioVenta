using CapaAccesoDatos;
using CapaAccesoDatos.Commands;
using CapaDeAplicacion.Services;
using CapaDeDominio.Commands;
using CapaDeDominio.Entity;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TEST_VENTA
{
    [TestFixture]
    public class VentaServiceTest
    {

        //public VentaServiceTest(IVentaService ventaService, IGenericRepository repository)
        //{
        //    this.ventaService = ventaService;
        //    this.repository = repository;
        //}

        [Test]
        public void CrearVenta()
        {
            
            Mock<IGenericRepository> genericsrepository = new Mock<IGenericRepository>();
            Mock<IMercadoPagoService> mercadopagoservice = new Mock<IMercadoPagoService>();

            genericsrepository.Setup(a=> a.Add<Venta>(new Venta {Id_carrito=4,Aprobada=false, FechaVenta= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) })).Returns(new Venta {Id_carrito=12});
            mercadopagoservice.Setup(a=> a.GetInitPoint("850")).Returns("url");

            VentaService ventaService = new VentaService(genericsrepository.Object, mercadopagoservice.Object);

            var sale = ventaService.InsertarVenta(4, "850");
            Assert.IsNotNull(sale);
        }




    }
}
