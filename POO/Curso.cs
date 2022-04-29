using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void adicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada.");
            Console.ReadLine();
        }

        public void adicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Saída registrada registrada.");
            Console.ReadLine();
        }

        public void exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"preco: {preco}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("===========================");
        }
    }
}
