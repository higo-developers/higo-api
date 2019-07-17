namespace HigoApi.Controllers
{
    public class DatosPagoDTO
    {
        public int id_operacion { get; set; }
        public string currency_id { get; set; }
        public string payer_email { get; set; }
        public float amount { get; set; }
        public string description { get; set; }
        public string concept_type { get; set; }
    }
}