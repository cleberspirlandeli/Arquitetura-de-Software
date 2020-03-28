using System;

namespace DesignPatterns
{
    // Concrete Observer
    internal class Observador : IObservador
    {
        public Observador(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }

        public void Notificar(Investimento investimento)
        {
            Console.WriteLine("Notificando {0} que {1} " +
                              "teve preço alterado para {2:C}", Nome, investimento.Simbolo, investimento.Valor);
        }


    }
}