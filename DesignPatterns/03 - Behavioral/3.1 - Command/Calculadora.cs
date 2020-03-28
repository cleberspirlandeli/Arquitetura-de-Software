using System;

namespace DesignPatterns
{
    internal class Calculadora
    {
        private int _valorAtual;

        public void Operacao(char operador, int valor)
        {
            switch (operador)
            {
                case '+': _valorAtual += valor; break;
                case '-': _valorAtual -= valor; break;
                case '*': _valorAtual *= valor; break;
                case '/': _valorAtual /= valor; break;
            }
            Console.WriteLine("(dado {1} {2}) - Valor atual = {0,3}", _valorAtual, operador, valor);
        }
    }
}