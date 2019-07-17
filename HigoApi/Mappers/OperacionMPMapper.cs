using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Models.DTO;
using HigoApi.Models;

namespace HigoApi.Mappers
{
    public class OperacionMPMapper
    {
        public static OperacionMPDTO ConvertirAOperacionMPDTO(dynamic op)
        {
            return new OperacionMPDTO
            {
                Id = op.id,
                Solicitante = op.collector_id,
                Pagador = op.payer_id,
                Monto = op.amount,
                Link_pago= op.init_point,
                Descripcion= op.description,
                Estado= op.status
            };
        }

        public static OperacionMp ConvertirAOperacionMP(OperacionMPDTO dto)
        {
            return new OperacionMp
            {
                Amount = dto.Monto,
                CollectorId = int.Parse(dto.Solicitante),
                Description = dto.Descripcion,
                IdOperacionHigo = dto.IdOperacion,
                IdOperacionMp = dto.Id,
                InitPoint = dto.Link_pago,
                PayerId = int.Parse(dto.Pagador),
                Status = dto.Estado,
            };
        }
    }
}
