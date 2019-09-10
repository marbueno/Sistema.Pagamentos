using Sistema.Pagamentos.Enum;
using Sistema.Pagamentos.Interface;
using Sistema.Pagamentos.Model.Request;
using Sistema.Pagamentos.Model.Response;

namespace Sistema.Pagamentos.Services
{
    public class IntegracaoPagamentoService : IIntegracaoPagamento
    {
        #region Variables

        private readonly IIntegracaoPagamento _integracaoPagamento;

        #endregion Variables

        #region Constructor

        public IntegracaoPagamentoService(bool isProduction, GatewayPagamento gatewayPagamento)
        {
            if (gatewayPagamento == GatewayPagamento.IUGU)
                _integracaoPagamento = new IUGUService(isProduction);
        }

        #endregion Constructor

        #region Methods

        public FaturaResponse GerarBoleto(FaturaRequest fatura)
        {
            return _integracaoPagamento.GerarBoleto(fatura);
        }

        #endregion Methods
    }
}