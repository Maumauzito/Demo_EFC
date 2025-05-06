using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json.Serialization;

namespace Demo_EFC.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }
    }

}
