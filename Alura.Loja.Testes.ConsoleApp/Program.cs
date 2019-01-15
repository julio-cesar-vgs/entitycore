using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();

                ExibeEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto()
                {
                    Nome = "Batata",
                    Categoria = "Alimento",
                    Preco = 2.99
                };

                //contexto.Produtos.Add(novoProduto);

                //Console.WriteLine("Foi inserido um item no banco");

                ExibeEntries(contexto.ChangeTracker.Entries());

                var p1 = contexto.Produtos.First();
                contexto.Produtos.Remove(p1);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                ExibeEntries(contexto.ChangeTracker.Entries());

                #region logando no console
                //    foreach (var p in produtos)
                //    {
                //        Console.WriteLine(p);
                //    }

                //    Console.WriteLine("=================");
                //    foreach (var e in contexto.ChangeTracker.Entries())
                //    {
                //        Console.WriteLine(e);
                //    }

                //    var p1 = produtos.Last();
                //    p1.Nome = "007 - O Espiao Que Me Amava";

                //    Console.WriteLine("=================");
                //    foreach (var e in contexto.ChangeTracker.Entries())
                //    {
                //        Console.WriteLine(e);
                //    }

                //    contexto.SaveChanges();
                //}
                #endregion
            }

            #region Informações do Crud
            //    static void Main(string[] args)
            //    {
            //        GravarUsandoAdoNet();
            //        RecuperarProdutos();
            //        GravarUsandoEntity();
            //        RecuperarProdutos();
            //        ExcluirProduto();
            //        RecuperarProdutos();
            //        AtualizarProduto();
            //    }

            //    private static void AtualizarProduto()
            //    {
            //        inclui um produto
            //        GravarUsandoEntity();
            //        RecuperarProdutos();

            //        atualiza o produto
            //        using (var repo = new ProdutoDAOEntity())
            //        {
            //            Produto primeiro = repo.Produtos().First();
            //            primeiro.Nome = "Cassino Royale - Editado";
            //            repo.Atualizar(primeiro);
            //        }
            //        RecuperarProdutos();
            //    }

            //    private static void ExcluirProduto()
            //    {
            //        var repo = new ProdutoDAOEntity();

            //        IList<Produto> produtos = repo.Produtos();

            //        foreach (Produto item in produtos)
            //        {
            //            repo.Remover(item);
            //        }
            //    }

            //    private static void RecuperarProdutos()
            //    {
            //        var repo = new ProdutoDAOEntity();
            //        IList<Produto> produtos = repo.Produtos();
            //        Console.WriteLine("Foram encontrados {0} produtos(s). ", produtos.Count);
            //        foreach (Produto item in produtos)
            //        {
            //            Console.WriteLine(item.Nome + " - " + item.Preco);
            //        }
            //    }

            //    private static void GravarUsandoEntity()
            //    {
            //        Produto p1 = new Produto();
            //        p1.Nome = "Harry Potter e a Ordem da Fênix";
            //        p1.Categoria = "Livros";
            //        p1.Preco = 19.89;

            //        Produto p2 = new Produto();
            //        p2.Nome = "Senhor dos Anéis 1";
            //        p2.Categoria = "Livros";
            //        p2.Preco = 19.89;

            //        Produto p3 = new Produto();
            //        p3.Nome = "O Monge e o Executivo";
            //        p3.Categoria = "Livros";
            //        p3.Preco = 19.89;

            //        using (var contexto = new ProdutoDAOEntity())
            //        {
            //            contexto.Adicionar(p1);
            //            contexto.Adicionar(p2);
            //            contexto.Adicionar(p3);
            //        }
            //    }

            //    private static void GravarUsandoAdoNet()
            //    {
            //        Produto p = new Produto();
            //        p.Nome = "Harry Potter e a Ordem da Fênix";
            //        p.Categoria = "Livros";
            //        p.Preco = 19.89;

            //        using (var repo = new ProdutoDAO())
            //        {
            //            repo.Adicionar(p);
            //        }
            //    }
            //}
            #endregion

        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("=================");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " +  e.State);
            }
        }
    }
}
