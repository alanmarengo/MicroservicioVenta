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
    public class VentaServiceTest: BaseTEST_VENTA
    {

        DatoDbContext db;
        GenericsRepository genericsRepository;
        VentaService ventaService;

        [SetUp]
        public void Setup()
        {
            db = ConstruirContexto();
            genericsRepository = new GenericsRepository(db);
            ventaService = new VentaService(genericsRepository);
        }




        [Test]
        public void CrearVenta()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var sale = ventaService.InsertarVenta(150);
                Assert.IsNotNull(sale);
                trans.Rollback();
            }
        }


        [Test]
        public void UpdateVenta()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var sale = ventaService.UpdateVenta(8, "approved");
                Assert.IsNotNull(sale);
                trans.Rollback();
            }
        }





    }
}
