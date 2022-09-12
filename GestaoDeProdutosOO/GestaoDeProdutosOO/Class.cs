using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutosOO
{
    internal class Class
    {

        enum Menu { Listagem = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum TipoDeProduto { ProdutoFisico = 1 , Ebook, Curso}

        static List<IEstoque> produtos = new List<IEstoque>();
        static void Main(string[] args)
        {

            Carregar();
            bool escolheuSair = false;

            while (!escolheuSair)
            {
            Console.WriteLine("Bem vindo ao Sistema de Estoque\n");
            Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar Entrada\n5-Registrar Saída\n6-Sair");
            int opcaoInt = int.Parse(Console.ReadLine());
            Menu opcao = (Menu)opcaoInt;

            switch (opcao)
            {
                case Menu.Listagem:
                        Listagem();
                    break;
                case Menu.Adicionar:
                        Cadastro();
                    break;
                case Menu.Remover:
                    break;
                case Menu.Entrada:
                    break;
                case Menu.Saida:
                    break;
                case Menu.Sair:
                    escolheuSair = true;
                    break;

            }
                Console.Clear();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Selecione o Tipo de Produto que você queira cadastrar\n");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            int opcaoint = int.Parse(Console.ReadLine());
            TipoDeProduto tipoDeProduto = (TipoDeProduto)opcaoint;

            switch (tipoDeProduto)
            {
                case TipoDeProduto.ProdutoFisico:
                    CadastroProdutoFIsico();
                    break;
                case TipoDeProduto.Ebook:
                    CadastroEbook();
                    break;
                case TipoDeProduto.Curso:
                    CadastroCurso();
                    break;
            }         
        }

        static void CadastroProdutoFIsico()
        {
            Console.WriteLine("Cadastrando produto Fisico\n");         
            Console.WriteLine("Informe o nome do produto que queira cadastrar");
            string nome = Console.ReadLine();           
            Console.WriteLine("Informe o preço do produto que queira cadastrar");
            float preco = float.Parse(Console.ReadLine());          
            Console.WriteLine("Informe o preço do frete do produto que queira cadastrar");
            float frete = float.Parse(Console.ReadLine());           
            ProdutoFisico produtoFisico = new ProdutoFisico(nome, preco, frete);           
            produtos.Add(produtoFisico);
            Salvar();
        }

        static void CadastroEbook()
        {
            Console.WriteLine("Cadastrando Ebook\n");           
            Console.WriteLine("Informe o nome do Ebook que queira cadastrar");
            string nome = Console.ReadLine();           
            Console.WriteLine("Informe o preço do Ebook que queira cadastrar");
            float preco = float.Parse(Console.ReadLine());          
            Console.WriteLine("Informe o autor do Ebook que queira cadastrar");
            string autor = Console.ReadLine();            
            Ebook ebook = new Ebook(nome, preco, autor);            
            produtos.Add(ebook);
            Salvar();
        }

        static void CadastroCurso()
        {
            Console.WriteLine("Cadastrando Curso\n");

            Console.WriteLine("Informe o nome do Curso que queira cadastrar");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o preço do Curso que queira cadastrar");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Informe o autor do Ebook que queira cadastrar");
            string autor = Console.ReadLine();
            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)formatter.Deserialize(stream);              
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

        static void Listagem()
        {
            Console.WriteLine("Lista dos Produtos\n");

            foreach(IEstoque produto in produtos)
            {
                produto.Exibir();
            }
            Console.ReadLine();
        }

    }
}
