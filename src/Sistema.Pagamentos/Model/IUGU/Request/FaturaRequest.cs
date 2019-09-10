using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sistema.Pagamentos.Model.Request
{
    public class FaturaRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string EmailCliente { get; set; }

        [JsonProperty(PropertyName = "cc_emails")]
        public string EmailComCopiaPara { get; set; }

        [JsonProperty(PropertyName = "due_date")]
        public string DataVencimento { get; set; }

        [JsonProperty(PropertyName = "ensure_workday_due_date")]
        public bool ConsiderarSomenteDiasUteis { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<Item> ListItensCobranca { get; set; }

        [JsonProperty(PropertyName = "custom_variables")]
        public List<CustomVariables> ListParametros { get; set; }

        [JsonProperty(PropertyName = "payer")]
        public Pagador Pagador { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string CodigoPedido { get; set; }
    }

    public class Item
    {
        [JsonProperty(PropertyName = "description")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Qtde { get; set; }

        [JsonProperty(PropertyName = "price_cents")]
        public int Valor { get; set; }

    }

    public class CustomVariables
    {
        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Valor { get; set; }

    }

    public class Pagador
    {
        [JsonProperty(PropertyName = "cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Endereco Endereco { get; set; }
    }

    public class Endereco
    {
        [JsonProperty(PropertyName = "zip_code")]
        public string CEP { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Logradouro { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Numero { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string Bairro { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string Cidade { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string Estado { get; set; }

        [JsonProperty(PropertyName = "complement")]
        public string Complemento { get; set; }
    }
}
