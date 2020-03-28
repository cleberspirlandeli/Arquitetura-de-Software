using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    public class Mensagem : IMessage, IEnumerable<IMessage>
    {
        private readonly List<IMessage> _lista = new List<IMessage>();

        public string Nome { get; set; }

        public Mensagem(string nome)
        {
            Nome = nome;
        }

        public void AdicionarFilha(IMessage filha)
        {
            _lista.Add(filha);
        }

        public void RemoverFilha(IMessage filha)
        {
            _lista.Remove(filha);
        }

        public IMessage ObterFilha(int index)
        {
            return _lista[index];
        }

        public IMessage ObterFilha(string nome)
        {
            return _lista.First(c => c.Nome == nome);
        }

        public IEnumerable<IMessage> ObterLista()
        {
            return _lista;
        }

        public IEnumerator<IMessage> GetEnumerator()
        {
            return ((IEnumerable<IMessage>)_lista).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IMessage>)_lista).GetEnumerator();
        }

        public void ExibirMensagens(int sub)
        {
            Console.WriteLine(new string('-', sub) + Nome);

            foreach (var mensagem in _lista)
            {
                mensagem.ExibirMensagens(sub + 2);
            }
        }
    }
}