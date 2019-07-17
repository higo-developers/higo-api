using System.Collections.Generic;
using System.Linq;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Utils;
using HigoApi.Validators;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class OperacionMPService : IOperacionMPService
    {
        private readonly HigoContext higoContext;

        public OperacionMPService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        //public void ActualizarOperacionMP(int idOpMP, OperacionMp opMP)
        //{
            
        //    throw new System.NotImplementedException();
        //}

        public void RegistrarOperacionMP(OperacionMp opMP)
        {
            higoContext.OperacionMp.Add(opMP);
            higoContext.SaveChanges();
        }

    }
}
