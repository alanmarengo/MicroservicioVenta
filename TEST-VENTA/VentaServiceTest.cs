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

        DatoDbContext db;
        GenericsRepository genericsRepository;
        VentaService ventaService;

        [SetUp]
        public void Setup()
        {
            db = new DatoDbContext();
            genericsRepository = new GenericsRepository(db);
            ventaService = new VentaService(genericsRepository);
        }




        [Test]
        public void CrearVenta()
        {
            var sale = ventaService.InsertarVenta(150);
            Assert.IsNotNull(sale);
        }


        [Test]
        public void UpdateVenta()
        {
            var sale = ventaService.UpdateVenta(8,"approved");
            Assert.IsNotNull(sale);
        }





    }
}
