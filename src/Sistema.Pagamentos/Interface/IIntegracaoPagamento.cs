using Sistema.Pagamentos.Model.Request;
using Sistema.Pagamentos.Model.Response;

namespace Sistema.Pagamentos.Interface
{
    public interface IIntegracaoPagamento
    {
        #region Methods

        FaturaResponse GerarBoleto(FaturaRequest fatura);

        #endregion Methods
    }
}
