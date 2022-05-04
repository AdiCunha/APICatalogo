using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("primeiro")]
        public ActionResult<Produto> GetPrimeiroProduto()
        {
            var produto = _context.Categoria.AsNoTracking().FirstOrDefault();

            if (produto is null)
            {
                return NotFound("Produtos não encontrados.");
            }

            return produto;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Categoria.AsNoTracking().ToList();

            if (produtos is null)
            {
                return NotFound("Produtos não encontrados.");
            }

            return produtos;
        }

        [HttpGet("{id:int:min(1)}", Name ="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Categoria.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }
            return produto;

        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            _context.Categoria.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Categoria.FirstOrDefault(p =>p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);


            if (produto is null)
            {
                return NotFound("Produto não localizado.");
            }

            _context.Categoria.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);






        }




    }
}
