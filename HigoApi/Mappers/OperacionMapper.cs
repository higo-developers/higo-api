using HigoApi.Models;
using HigoApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Mappers
{
    public class OperacionMapper
    {
        public static OperacionDTO ConvertirAOperacionDTO(Operacion op)
        {
            return new OperacionDTO
            {
                IdOperacion = op.IdOperacion,
                IdAdquiriente = op.IdAdquirente,
                IdVehiculo = op.IdVehiculo,
                CodEstado = op.IdEstadoOperacionNavigation.Codigo,
                Estado = op.IdEstadoOperacionNavigation.Descripcion,
                FechaHoraDesde = op.FechaHoraDesde,
                FechaHoraHasta = op.FechaHoraHasta,
                Prestador = op.IdVehiculoNavigation.IdPrestadorNavigation.Apellido + ", " + op.IdVehiculoNavigation.IdPrestadorNavigation.Nombre,
                Vehiculo = op.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + op.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion,
                MontoAcordado = op.MontoAcordado,
                MontoEfectivo = op.MontoEfectivo
            }
            ;
        }

        public static List<OperacionDTO> ConvertirAOperacionDTOLista(List<Operacion> ops)
        {
            return ops.ConvertAll(op => ConvertirAOperacionDTO(op));
        }
        public static Operacion ConvertirAOperacion(OperacionDTO opDTO)
        {
            return null;
        }
    }
}
