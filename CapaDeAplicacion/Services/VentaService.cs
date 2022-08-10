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
        Venta InsertarVenta(int carritoID);
        Venta UpdateVenta(int ventaID, string state);
    }
    public class VentaService : IVentaService
    {
        private readonly IGenericRepository _repository;

        public VentaService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Venta InsertarVenta(int carritoID)
        {
            Venta venta = new Venta()
            {
                FechaVenta = DateTime.Now,
                Id_carrito = carritoID,
                Aprobada = false
            };
            return _repository.Add<Venta>(venta);
        }

        public Venta UpdateVenta(int ventaID, string state)
        {
            var sale = _repository.GetBy<Venta>(ventaID);
            sale.Aprobada = state == "approved" ? true : false;
            return _repository.Update<Venta>(sale);
        }
    }
}
