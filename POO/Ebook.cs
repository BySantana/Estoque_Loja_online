using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void adicionarEntrada()
        {
            Console.WriteLine("Não é possível dar entrada no estoque de um E-book");
            Console.ReadLine();
        }

        public void adicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no E-book {nome}");
            Console.WriteLine("Digite a quantidade de vendas: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Venda registrada.");
            Console.ReadLine();
        }

        public void exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"preco: {preco}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("===========================");
        }
    }
}
