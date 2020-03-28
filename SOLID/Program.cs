using System;
//using SOLID.LSP.Violacao;
using SOLID.OCP.Solucao_Extension_Methods;
using CalculoArea = SOLID.LSP.Solucao.CalculoArea;

namespace SOLID
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Escolha a operação");
            Console.WriteLine("1 - OCP");
            Console.WriteLine("2 - LSP");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    CaixaEletronico.Operacoes();
                    break;
                case '2':
                    CalculoArea.Calcular();
                    break;
            }
        }
    }
}