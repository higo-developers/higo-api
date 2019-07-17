using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json.Linq;
using HigoApi.Mappers;
using HigoApi.Models.DTO;
using HigoApi.Models;
using HigoApi.Services;

namespace HigoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoMPController : ControllerBase
    {
        private readonly IOperacionMPService mpService;
        private const string AccesToken = "{access_token}";

        public PagoMPController(IOperacionMPService mpService)
        {
            this.mpService = mpService;
        }

        
        // GET api/values
        [HttpPost(AccesToken)]

        public IActionResult SolicitarPago(string Access_token, [FromBody] DatosPagoDTO DatosPago)
        {
            RestClient client = new RestClient("https://api.mercadopago.com/");
            //RestRequest request = new RestRequest("money_requests?access_token=APP_USR-8487035112745025-071015-165cafc5d2aaeb0a0c67e7b9ab4e3f18-450906215", Method.POST);
            RestRequest request = new RestRequest("money_requests?"+Access_token, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //request.AddUrlSegment("access_token", "APP_USR-8487035112745025-071015-165cafc5d2aaeb0a0c67e7b9ab4e3f18-450906215");
            var body = new
            {
                DatosPago.currency_id,
                DatosPago.payer_email,
                DatosPago.amount,
                DatosPago.description,
                DatosPago.concept_type
            };
            request.AddJsonBody(body);

            var response = client.Execute(request).Content;
            dynamic jsonObject = JObject.Parse(response);
            OperacionMPDTO OperacionMPDTO = OperacionMPMapper.ConvertirAOperacionMPDTO(jsonObject);
            OperacionMPDTO.IdOperacion = DatosPago.id_operacion;
            OperacionMp OperacionMP = OperacionMPMapper.ConvertirAOperacionMP(OperacionMPDTO);
            mpService.RegistrarOperacionMP(OperacionMP);

            //string id = jsonObject.id;
            //jsonObject.status;
            return Ok(response);
        }

    }
}