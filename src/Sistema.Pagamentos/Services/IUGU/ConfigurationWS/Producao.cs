using Sistema.Pagamentos.Services.SoftwareExpress.Interface;

namespace Sistema.Pagamentos.Services.SoftwareExpress.ConfigurationWS
{
    public class Producao : IConfiguration
    {
        public string Url
        {
            get { return "https://api.iugu.com/v1/"; }
        }
        public string Token
        {
            get { return "57d1ecc8a045c20fb6ac9a61043dc4b4"; }
        }
    }
}
