using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models.DTO
{
    public class OperacionMPDTO
    {
        public int Id { get; set; }
        public int IdOperacion { get; set; }
        public string Solicitante { get; set; }
        public string Pagador { get; set; }
        public string Monto { get; set; }
        public string Link_pago { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}