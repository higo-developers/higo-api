using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Locacion
    {
        public Locacion()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdLocacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public string Partido { get; set; }
        public string Provincia { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}