using System;

namespace HigoApi.Utils
{
    public class VehiculoUtils
    {
        public bool MatchLocationIfPresent(string locacionVehiculo, string locacion)
        {
            return string.IsNullOrWhiteSpace(locacion)
                   || locacionVehiculo.Contains(locacion, StringComparison.OrdinalIgnoreCase);
        }
    }
}