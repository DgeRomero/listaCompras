using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
