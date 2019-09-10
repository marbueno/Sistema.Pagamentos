using Xunit;
using Sistema.Pagamentos.Services;
using Sistema.Pagamentos.Model.Request;
using Sistema.Pagamentos.Model.Response;
using System;
using System.Collections.Generic;

namespace Sistema.Pagamentos
{
    public class IUGUTest
    {
        private FaturaRequest faturaRequest;

        IntegracaoPagamentoService iuguService { get; }
        public IUGUTest()
        {
            iuguService = new IntegracaoPagamentoService(false, Enum.GatewayPagamento.IUGU);
        }

        [Fact]
        public void Deve_Gerar_Boleto()
        {
            List<Item> listItens = new List<Item>();
            listItens.Add(new Item()
            {
                Descricao = "PRODUTO 0001",
                Qtde = 1,
                Valor = 120 //Equivalente a R$ 1,20
            });

            Pagador pagador = new Pagador()
            {

            };

            faturaRequest = new FaturaRequest()
            {
                EmailCliente = "marbue@ig.com.br",
                EmailComCopiaPara = "",
                DataVencimento = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),
                ConsiderarSomenteDiasUteis = true,
                ListItensCobranca = listItens,
                ListParametros = new List<CustomVariables>(),
                Pagador = new Pagador()
                {
                    CpfCnpj = "32518799877",
                    Nome = "Marcelo Bueno",
                    Endereco = new Endereco()
                    {
                        CEP = "02130040",
                        Logradouro = "Rua Orindiuva",
                        Numero = "345",
                        Complemento = "Apto 63",
                        Bairro = "Vila Maria",
                        Estado = "SP",
                        Cidade = "São Paulo"
                    }

                },
                CodigoPedido = "0001"
            };

            FaturaResponse faturaResponse = iuguService.GerarBoleto(faturaRequest);

            Assert.True(faturaResponse.ListErros == null);
        }
    }
}
