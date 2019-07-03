using System;
using System.Collections.Generic;
using HigoApi.Models;

namespace HigoApi.Utils
{
    public class VehiculoUtils
    {
        private const string ABS = "ABS";
        private const string Airbag = "Airbag";
        private const string AireAcondicionado = "Aire acondicionado";
        private const string Alarma = "Alarma";
        private const string CierreCentralizado = "Cierre centralizado";
        private const string ControlDeTracción = "Control de tracción";
        private const string DireccionHidraulica = "Dirección hidraulica";
        private const string RompenieblasDelantero = "Rompenieblas delantero";
        private const string RompenieblasTrasero = "Rompenieblas trasero";
        private const string TapizadoDeCuero = "Tapizado de cuero";
        private const string DireccionAsistida = "Dirección asistida";

        public bool MatchLocationIfPresent(string locacionVehiculo, string locacion)
        {
            return string.IsNullOrWhiteSpace(locacion)
                   || locacionVehiculo.Contains(locacion, StringComparison.OrdinalIgnoreCase);
        }

        public List<string> EquipamientoAsList(Vehiculo vehiculo)
        {
            List<string> equipamientoList = new List<string>();

            if (vehiculo.Abs.HasValue && vehiculo.Abs.Value)
                equipamientoList.Add(ABS);

            if (vehiculo.Ac.HasValue && vehiculo.Ac.Value)
                equipamientoList.Add(AireAcondicionado);

            if (vehiculo.Airbag.HasValue && vehiculo.Airbag.Value)
                equipamientoList.Add(Airbag);

            if (vehiculo.Alarma.HasValue && vehiculo.Alarma.Value)
                equipamientoList.Add(Alarma);

            if (vehiculo.CierreCentralizado.HasValue && vehiculo.CierreCentralizado.Value)
                equipamientoList.Add(CierreCentralizado);

            if (vehiculo.ControlTraccion.HasValue && vehiculo.ControlTraccion.Value)
                equipamientoList.Add(ControlDeTracción);

            if (vehiculo.Da.HasValue && vehiculo.Da.Value)
                equipamientoList.Add(DireccionAsistida);

            if (vehiculo.Dh.HasValue && vehiculo.Dh.Value)
                equipamientoList.Add(DireccionHidraulica);

            if (vehiculo.RompenieblasDelantero.HasValue && vehiculo.RompenieblasDelantero.Value)
                equipamientoList.Add(RompenieblasDelantero);

            if (vehiculo.RompenieblasTrasero.HasValue && vehiculo.RompenieblasTrasero.Value)
                equipamientoList.Add(RompenieblasTrasero);

            if (vehiculo.TapizadoCuero.HasValue && vehiculo.TapizadoCuero.Value)
                equipamientoList.Add(TapizadoDeCuero);

            return equipamientoList;
        }
    }
}