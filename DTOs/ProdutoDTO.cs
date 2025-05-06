using Demo_EFC.Model;

namespace Demo_EFC.DTOs
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
