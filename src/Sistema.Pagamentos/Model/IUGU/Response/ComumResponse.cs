using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sistema.Pagamentos.Model.IUGU.Response
{
    public class ComumResponse
    {
        [JsonProperty(PropertyName = "errors")]
        public List<string> ListErros { get; set; }
    }
}
