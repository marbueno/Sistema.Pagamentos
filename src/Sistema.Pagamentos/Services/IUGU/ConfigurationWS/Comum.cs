using Sistema.Pagamentos.Services.SoftwareExpress.Interface;
using System.Collections.Specialized;
using System;
using Sistema.Utils.WebServices;
using Sistema.Utils.Enums.WebServiceEnum;

namespace Sistema.Pagamentos.Services.SoftwareExpress.ConfigurationWS
{
    public class Comum
    {
        #region Variables 

        public const string contentType = "application/json; encoding='utf-8'";
        private readonly IConfiguration _configuration;

        #endregion Variables

        #region Constructor

        public Comum(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion Constructor

        #region Methods

        public WebServiceModel GetModelServices(Verbs methodType, string methodName, string requestData = null)
        {
            string url = $"{_configuration.Url}{methodName}";

            return new WebServiceModel()
            {
                Url = url,
                RequestHeader = GetBasicAuthentication(),
                RequestData = requestData,
                ContentType = contentType,
                MethodType = methodType
            };
        }

        private NameValueCollection GetBasicAuthentication()
        {
            NameValueCollection nvcHeader = new NameValueCollection();

            string encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(_configuration.Token + ":"));

            nvcHeader.Add("Authorization", $"Basic {encoded}");

            return nvcHeader;
        }

        #endregion Methods
    }
}
