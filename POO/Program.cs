using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace POO
{
    internal class Program
    {
        static public List<IEstoque> produtos = new List<IEstoque>();
        
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1 - Listar \n2 - Adicionar \n3 - Remover \n4 - Entrada \n5 - Saída \n6 - Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }else
                {
                    escolheuSair = true;
                }
        
                Console.Clear();
            }
        }
        static void Listagem()
        {
            int id = 0;
            Console.WriteLine("Lista de Produtos");
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine(id);
                produto.exibir();
                id++;
            }
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que você quer dar uma entrada: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].adicionarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que você quer dar baixa: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].adicionarSaida();
                Salvar();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de produto:");
            Console.WriteLine("1 - Produto Físico \n2 - Ebook \n3 - Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);

            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }
        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produtos físicos");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebooks");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Ebook ebook = new Ebook(nome, preco, autor);
            produtos.Add(ebook);
            Salvar();
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Cursos");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produto.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produto.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();  
        }
        
    }

    
}
