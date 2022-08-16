using CapaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_VENTA
{
    public class BaseTEST_VENTA
    {
        DatoDbContext db = null;
        protected DatoDbContext ConstruirContexto()
        {
            if (db==null)
            {
                var opciones = new DbContextOptionsBuilder<DatoDbContext>().UseSqlServer("Server=NTB707\\SQLEXPRESS;Database=VentasDB;Uid=sa;Pwd='Emerix01';",
                options => { }).Options;
                db= new DatoDbContext(opciones);
                return db;
            }
            return db;
        }
    }
}
