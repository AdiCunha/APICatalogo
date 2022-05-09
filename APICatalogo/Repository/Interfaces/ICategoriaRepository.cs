using APICatalogo.Models;

namespace APICatalogo.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriaProdutos();
    }
}
