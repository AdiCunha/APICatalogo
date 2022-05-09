using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository.Implementacao
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Categoria> GetCategoriaProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
