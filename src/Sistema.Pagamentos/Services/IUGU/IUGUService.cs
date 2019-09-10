using Sistema.Pagamentos.Interface;
using Sistema.Pagamentos.Services.SoftwareExpress.ConfigurationWS;
using Sistema.Pagamentos.Services.SoftwareExpress.Interface;
using Sistema.Pagamentos.Model.Request;
using Sistema.Pagamentos.Model.Response;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Sistema.Utils.WebServices;
using Sistema.Utils.Enums.WebServiceEnum;
using Sistema.Pagamentos.Model.IUGU.Response;

namespace Sistema.Pagamentos.Services
{
    internal class IUGUService : IIntegracaoPagamento
    {
        #region Variables

        private readonly bool _isProduction;
        private readonly IConfiguration _configuration;

        #endregion Variables

        #region Constructor

        public IUGUService(bool isProduction)
        {
            _isProduction = isProduction;

            if (_isProduction)
                _configuration = new Producao();
            else
                _configuration = new Homologacao();
        }

        #endregion Constructor

        #region Methods

        private string ConsumeWS(Verbs verb, string methodName, string requestData = null)
        {
            WebServiceBase wsIUGU = new WebServiceBase(new Comum(_configuration).GetModelServices(verb, methodName, requestData));

            string responseStr = string.Empty;

            var response = wsIUGU.Call();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                responseStr = new StreamReader(responseStream).ReadToEnd();
            }

            return responseStr;
        }

        public FaturaResponse GerarBoleto(FaturaRequest cartao)
        {
            FaturaResponse _faturaResponse = new FaturaResponse();

            try
            {
                string responseStr = ConsumeWS(Verbs.POST, "invoices", JsonConvert.SerializeObject(cartao));

                if (!string.IsNullOrEmpty(responseStr))
                    _faturaResponse = JsonConvert.DeserializeObject<FaturaResponse>(responseStr);
                else
                {
                    _faturaResponse.ListErros = new List<string>();
                    _faturaResponse.ListErros.Add("Não foi possível gerar o boleto");
                }
            }
            catch (Exception ex)
            {
                _faturaResponse.ListErros = new List<string>();
                _faturaResponse.ListErros.Add($"Não foi possível gerar o boleto: [{ex.Message}]");
            }

            return _faturaResponse;
        }

        #endregion Methods
    }
}
