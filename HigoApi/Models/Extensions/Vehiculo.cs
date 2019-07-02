using System;
using HigoApi.Models.DTO;

namespace HigoApi.Models
{
    public partial class Vehiculo
    {
        public Vehiculo(PerfilVehiculoDTO dto)
        {
            if (dto.Id != null) IdVehiculo = (int) dto.Id;
            IdModeloMarca = dto.Modelo;
            IdCilindrada = dto.Cilindrada;
            Anno = Int32.Parse(dto.Anno);
            Ac = dto.Ac;
            Da = dto.Da;
            Dh = dto.Dh;
            Alarma = dto.Alarma;
            CierreCentralizado = dto.CierreCentralizado;
            RompenieblasDelantero = dto.RompenieblasDelantero;
            RompenieblasTrasero = dto.RompenieblasTrasero;
            Airbag = dto.Airbag;
            Abs = dto.Abs;
            ControlTraccion = dto.ControlTraccion;
            TapizadoCuero = dto.TapizadoCuero;
            Patente = dto.Patente;
        }
    }
}