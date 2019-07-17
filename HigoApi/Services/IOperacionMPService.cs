using System.Collections.Generic;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IOperacionMPService
    {
        void RegistrarOperacionMP(OperacionMp opMP);
        //OperacionMp ActualizarOperacionMP(int idOpMP, OperacionMp opMP);

    }
}