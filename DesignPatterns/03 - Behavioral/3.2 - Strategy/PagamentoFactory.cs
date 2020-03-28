using System;

namespace DesignPatterns
{
    public class PagamentoFactory
    {
        // Nesse caso seria necessário usar um tipo de Service Locator
        // Ou injetar todas as instâncias para retornar apenas uma
        public static IPagamento CreatePagamento(MeioPagamento meioPagamento)
        {
            switch (meioPagamento)
            {
                case MeioPagamento.CartaoCredito:
                    return new PagamentoCartaoCreditoService(
                               new PagamentoCartaoCreditoFacade(
                               new PayPalGateway(),
                               new ConfigurationManager()));

                case MeioPagamento.Boleto:
                    return new PagamentoBoletoService(new PagamentoBoletoFacade());

                case MeioPagamento.TransferenciaBancaria:
                    return new PagamentoTransferenciaService(new PagamentoTransferenciaFacade());

                default:
                    throw new ApplicationException("Meio de Pagamento não conhecido");
            }
        }
    }
}