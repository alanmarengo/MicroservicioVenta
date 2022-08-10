using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDeDominio.DTOs
{
    public class VentaUpdateResponseDto
    {
        public int Id { get; set; }
        public string state { get; set; }
        public DateTime FechaUpdate { get; set; }

    }
}
