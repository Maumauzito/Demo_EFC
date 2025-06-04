using Demo_EFC.Model;
using System.Text.Json.Serialization;

namespace Demo_EFC.DTOs
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
