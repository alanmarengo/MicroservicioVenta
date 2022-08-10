using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using CapaDeDominio.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeAplicacion.Services
{

    public interface IVentaService
    {

        ResponseCreateSaleDto InsertarVenta(int carritoID, string precio);
        VentaUpdateResponseDto UpdateVenta(int ventaID, string state);


    }
    public class VentaService : IVentaService
    {
        private readonly IGenericRepository _repository;
        private readonly IQueryVenta query;
        private readonly IMercadoPagoService mercadoPagoService;

        public VentaService(IGenericRepository repository, IQueryVenta query, IMercadoPagoService mercadoPagoService)
        {
            _repository = repository;
            this.query = query;
            this.mercadoPagoService = mercadoPagoService;
        }

        public ResponseCreateSaleDto InsertarVenta(int carritoID, string precio)
        {
            Venta venta = new Venta()
            {
                FechaVenta = DateTime.Today,
                Id_carrito = carritoID,
                Aprobada = false
            };

            string urlPago = mercadoPagoService.GetInitPoint(precio);
            var sale= _repository.Add<Venta>(venta);

            return new ResponseCreateSaleDto {IdSale=sale.VentaId, UrlPayment=urlPago };
        }

        public VentaUpdateResponseDto UpdateVenta(int ventaID, string state)
        {
            var sale = _repository.GetBy<Venta>(ventaID);
            sale.Aprobada = state == "approved" ? true : false;
            _repository.Update<Venta>(sale);

            return new VentaUpdateResponseDto { Id = sale.VentaId, state = state, FechaUpdate = DateTime.Now};
        }
    }
}
