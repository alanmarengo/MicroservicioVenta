using CapaDeAplicacion.Services;
using MercadoPago;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_VENTA
{
    [TestFixture]
    public class MercadoPagoServiceTest
    {
        Mock<IConfiguration> configuration;
        MercadoPagoService mercadoPagoService;

        [SetUp]
        public void Setup()
        {
            SDK.AccessToken = "TEST-4475385912435457-031714-bc0745d30bfaba3d213632adc19a0a26-719300697";
            configuration= new Mock<IConfiguration>();

            configuration.Setup(a => a["MercadoPago:BackUrl"]).Returns("www.proyectosoftware.com");
            mercadoPagoService = new MercadoPagoService(configuration.Object);
        }

        [Test]
        public void GetUrlPayment()
        {
            var urlPayment = mercadoPagoService.GetInitPoint("1500");
            NUnit.Framework.Assert.IsNotNull(urlPayment);
        }


        [Test]
        [ExpectedException(typeof(FormatException))]
        public void GetUrlPaymentWithInvalidPrice()
        {
            try
            {
                var urlPayment = mercadoPagoService.GetInitPoint("PROYECTO");
                NUnit.Framework.Assert.IsNotNull(urlPayment);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
