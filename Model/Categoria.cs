﻿namespace Demo_EFC.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
