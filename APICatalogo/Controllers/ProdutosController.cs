using APICatalogo.Context;
using APICatalogo.DTOs;
using APICatalogo.Filters;
using APICatalogo.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProdutosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<ProdutoDTO>> Get()
        {
            var produtos = _context.Categoria.AsNoTracking().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);

            return produtosDTO;
        }

        [HttpGet("{id:int:min(1)}", Name ="ObterProduto")]
        public ActionResult<ProdutoDTO> Get(int id)
        {
            var produto = _context.Categoria.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;

        }

        [HttpPost]
        public ActionResult Post(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _context.Categoria.Add(produto);
            _context.SaveChanges();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produtoDTO);
        }

        [HttpPut]
        public ActionResult Put(int id, ProdutoDTO produtoDto)
        {
            if (id != produtoDto.ProdutoId)
            {
                return BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ProdutoDTO> Delete(int id)
        {
            var produto = _context.Categoria.FirstOrDefault(p =>p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);


            if (produto is null)
            {
                return NotFound("Produto não localizado.");
            }

            _context.Categoria.Remove(produto);
            _context.SaveChanges();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);






        }




    }
}
