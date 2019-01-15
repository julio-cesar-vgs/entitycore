namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Compra
    {
        public int Quantidade { get; internal set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
        public int Id { get; set; }


        public override string ToString()
        {
            return $"Compra: {this.Id}, {this.Produto}, {this.Preco}, {this.Quantidade} ";
        }
    }
}