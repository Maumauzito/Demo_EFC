using Demo_EFC.Context;
using Demo_EFC.DTOs;
using Demo_EFC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Demo_EFC.Controllers
{
    // Controllers/ProdutosController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _context.Produtos.Include(p => p.Categoria).ToList();
            return Ok(JsonSerializer.Serialize(produtos));
        }

        [HttpPost]
        public IActionResult CreateProduto([FromBody] string produtoDto)
        {
            var produtos = JsonSerializer.Deserialize<ProdutoDTO>(produtoDto);

            if (produtos == null)
                return BadRequest("");
             var produto = new Produto();



            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
        }
    }

}
