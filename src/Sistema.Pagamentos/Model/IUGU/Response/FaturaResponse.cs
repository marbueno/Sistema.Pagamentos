using Newtonsoft.Json;
using Sistema.Pagamentos.Model.IUGU.Response;

namespace Sistema.Pagamentos.Model.Response
{
    public class FaturaResponse : ComumResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "secure_url")]
        public string LinkFatura { get; set; }

        [JsonProperty(PropertyName = "bank_slip")]
        public Boleto Boleto { get; set; }
    }

    public class Boleto
    {
        [JsonProperty(PropertyName = "digitable_line")]
        public string LinhaDigitavel { get; set; }

        [JsonProperty(PropertyName = "barcode_data")]
        public string CodigoBarras { get; set; }

        [JsonProperty(PropertyName = "barcode")]
        public string LinkBoleto { get; set; }
    }
}
