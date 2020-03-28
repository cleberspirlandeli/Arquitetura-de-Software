using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class ExecucaoStrategy
    {
        public static void Executar()
        {
            var produtos = new List<Produto>
            {
                new Produto{Nome = "Tenis Adidas", Valor = new Random().Next(500)},
                new Produto{Nome = "Camisa Boliche", Valor = new Random().Next(500)},
                new Produto{Nome = "Raquete Tenis", Valor = new Random().Next(500)}
            };

            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                Produtos = produtos
            };

            var meioPagamentoCredito = new Pagamento
            {
                MeioPagamento = MeioPagamento.CartaoCredito,
                CartaoCredito = "5555 2222 5555 9999"
            };

            var meioPagamentoBoleto = new Pagamento
            {
                MeioPagamento = MeioPagamento.Boleto
            };

            var meioPagamentoTransferencia = new Pagamento
            {
                MeioPagamento = MeioPagamento.TransferenciaBancaria,
                CartaoCredito = "5555 2222 5555 9999"
            };

            #region Forma Simples

            var pedidoCredito = new PedidoService(
                                   new PagamentoCartaoCreditoService(
                                   new PagamentoCartaoCreditoFacade(
                                   new PayPalGateway(),
                                   new ConfigurationManager())));
            var pagamentoCredito = pedidoCredito.RealizarPagamento(pedido, meioPagamentoCredito);
            Console.WriteLine(pagamentoCredito.Status);

            Console.WriteLine("-------------------------------------------------------");

            var pedidoBoleto = new PedidoService(
                                   new PagamentoBoletoService(
                                   new PagamentoBoletoFacade()));

            var pagamentoBoleto = pedidoBoleto.RealizarPagamento(pedido, meioPagamentoBoleto);
            Console.WriteLine(pagamentoBoleto.Status);

            Console.WriteLine("-------------------------------------------------------");

            var pedidoTransferencia = new PedidoService(
                                          new PagamentoTransferenciaService(
                                          new PagamentoTransferenciaFacade()));

            var pagamentoTransferencia = pedidoTransferencia.RealizarPagamento(pedido, meioPagamentoBoleto);
            Console.WriteLine(pagamentoTransferencia.Status);

            Console.WriteLine("-------------------------------------------------------");

            #endregion

            #region Forma Elegante

            var pedidoCredito2 = new PedidoService(PagamentoFactory.CreatePagamento(meioPagamentoCredito.MeioPagamento));
            var pagamentoCredito2 = pedidoCredito2.RealizarPagamento(pedido, meioPagamentoCredito);
            Console.WriteLine(pagamentoCredito2.Status);

            Console.WriteLine("-------------------------------------------------------");

            var pedidoBoleto2 = new PedidoService(PagamentoFactory.CreatePagamento(meioPagamentoBoleto.MeioPagamento));
            var pagamentoBoleto2 = pedidoBoleto2.RealizarPagamento(pedido, meioPagamentoBoleto);
            Console.WriteLine(pagamentoBoleto2.Status);

            Console.WriteLine("-------------------------------------------------------");

            var pedidoTransferencia2 = new PedidoService(PagamentoFactory.CreatePagamento(meioPagamentoTransferencia.MeioPagamento));
            var pagamentoTransferencia2 = pedidoTransferencia2.RealizarPagamento(pedido, meioPagamentoTransferencia);
            Console.WriteLine(pagamentoTransferencia2.Status);

            #endregion
        }
    }
}