using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;  
            this.preco = preco;
            this.frete = frete;
        }

        public void adicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada.");
            Console.ReadLine();           
        }

        public void adicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar baixa: ");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;
            Console.WriteLine("Saída registrada.");
            Console.ReadLine();
        }

        public void exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"preco: {preco}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Quantidade em estoque: {estoque}");
            Console.WriteLine("===========================");
        }
    }
}
