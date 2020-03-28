using System;

namespace DesignPatterns
{
    internal class CalculadoraCommand : Commander
    {
        private char _operador;
        private int _valor;
        private readonly Calculadora _calculadora;

        public CalculadoraCommand(Calculadora calculadora, char operador, int valor)
        {
            _calculadora = calculadora;
            _operador = operador;
            _valor = valor;
        }

        public char Operator
        {
            set => _operador = value;
        }

        public int Operand
        {
            set => _valor = value;
        }

        public override void Executar()
        {
            _calculadora.Operacao(_operador, _valor);
        }

        public override void Desfazer()
        {
            _calculadora.Operacao(Desfazer(_operador), _valor);
        }

        private static char Desfazer(char operador)
        {
            switch (operador)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new ArgumentException("Operador desconhecido");
            }
        }
    }
}