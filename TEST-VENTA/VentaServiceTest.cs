using CapaAccesoDatos;
using CapaAccesoDatos.Commands;
using CapaDeAplicacion.Services;
using CapaDeDominio.Commands;
using CapaDeDominio.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                NUnit.Framework.Assert.IsNotNull(sale);
                trans.Rollback();
            }
        }



        [Test]
        [ExpectedException(typeof(FormatException))]
        public void CrearVentaConCaracterInvalido()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    var sale = ventaService.InsertarVenta(int.Parse("PROYECTO"));
                }
                catch(Exception ex) 
                {
                    
                }
            }
        }

        [Test]
        public void UpdateVenta()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var sale = ventaService.UpdateVenta(8, "approved");
                NUnit.Framework.Assert.IsNotNull(sale);
                trans.Rollback();
            }
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void UpdateVentaConCaracterVentaInvalido()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {

                    var sale = ventaService.UpdateVenta(int.Parse("PROYECTO"), "approved");
                    trans.Rollback();
                }
                catch (Exception ex)
                {

                }
            }
        }



    }
}
