using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class OperacionMp
    {
        public int IdOperacionMp { get; set; }
        public int IdOperacionHigo { get; set; }
        public string Amount { get; set; }
        public int? CollectorId { get; set; }
        public int? PayerId { get; set; }
        public string Description { get; set; }
        public string InitPoint { get; set; }
        public string Status { get; set; }

        public virtual Operacion IdOperacionHigoNavigation { get; set; }
    }
}
