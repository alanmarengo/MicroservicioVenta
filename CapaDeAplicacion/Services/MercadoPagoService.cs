using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Common;

namespace CapaDeAplicacion.Services
{
    public interface IMercadoPagoService
    {
        public string GetInitPoint(string Price);
    }


    public class MercadoPagoService : IMercadoPagoService
    {
        private readonly IConfiguration _configuration;

        public MercadoPagoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetInitPoint(string Price)
        {
            Preference preference = new Preference()
            {
                Items = new List<Item> { new Item()
            {
                Title="Pedido de proyecto software",
                Quantity=1,
                UnitPrice =decimal.Parse(Price)
            }},
                BackUrls = new BackUrls()
                {
                    Success = $"{_configuration["MercadoPago:BackUrl"]}"
                },
                AutoReturn = AutoReturnType.approved
            };

            preference.Save();
            return preference.InitPoint;
        }
    }
}
