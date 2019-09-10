using Sistema.Pagamentos.Services.SoftwareExpress.Interface;

namespace Sistema.Pagamentos.Services.SoftwareExpress.ConfigurationWS
{
    public class Homologacao : IConfiguration
    {
        public string Url
        {
            get { return "https://api.iugu.com/v1/"; }
        }
        public string Token
        {
            get { return "8b9e51833fb7baeaa17826e793617c30"; }
        }
    }
}
