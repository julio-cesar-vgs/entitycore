using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //RecuperarProdutos();
            GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProduto();
            RecuperarProdutos();
        }

        private static void ExcluirProduto()
        {
            LojaContext repo = new LojaContext();

            IList<Produto> produtos = repo.Produtos.ToList();

            foreach (Produto item in produtos)
            {
                repo.Produtos.Remove(item);
            }
            repo.SaveChanges();
        }

        private static void RecuperarProdutos()
        {
            LojaContext repo = new LojaContext();
            IList<Produto> produtos = repo.Produtos.ToList();
            Console.WriteLine("Foram encontrados {0} produtos(s). ", produtos.Count);
            foreach (Produto item in produtos)
            {
                Console.WriteLine(item.Nome + " - " + item.Preco);
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p1 = new Produto();
            p1.Nome = "Harry Potter e a Ordem da Fênix";
            p1.Categoria = "Livros";
            p1.Preco = 19.89;

            Produto p2 = new Produto();
            p2.Nome = "Senhor dos Anéis 1";
            p2.Categoria = "Livros";
            p2.Preco = 19.89;

            Produto p3 = new Produto();
            p3.Nome = "O Monge e o Executivo";
            p3.Categoria = "Livros";
            p3.Preco = 19.89;

            using (LojaContext contexto = new LojaContext())
            {
                contexto.Produtos.AddRange(p1, p2, p3);

                contexto.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            //Produto p = new Produto();
            //p.Nome = "Harry Potter e a Ordem da Fênix";
            //p.Categoria = "Livros";
            //p.Preco = 19.89;

            //using (var repo = new ProdutoDAO())
            //{
            //    repo.Adicionar(p);
            //}
        }
    }
}
