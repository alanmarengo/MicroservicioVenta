using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDeAplicacion.Services;
using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _servicio;
        private readonly IMercadoPagoService _mercadoPagoService;

        public VentaController(IVentaService servicio, IMercadoPagoService mercadoPagoService)
        {
            _servicio = servicio;
            _mercadoPagoService = mercadoPagoService;
        }

        [Route("InsertarVenta")]
        [HttpPost]
        public IActionResult InsertarCarritoCliente(int carritoID)
        {
            try
            {
                return new JsonResult(_servicio.InsertarVenta(carritoID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [Route("UpdateVenta")]
        [HttpPost]
        public IActionResult UpdateVenta(int ventaID, string state)
        {
            try
            {
                return new JsonResult(_servicio.UpdateVenta(ventaID, state)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("GetUrlPayment")]
        [HttpGet]
        public IActionResult GetUrlPayment(string price)
        {
            try
            {
                return new JsonResult(_mercadoPagoService.GetInitPoint(price)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }







    }
}
