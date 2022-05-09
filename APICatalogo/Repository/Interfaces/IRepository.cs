using System.Linq.Expressions;

namespace APICatalogo.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();

        T GetById(Expression<Func<T,bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

    }
}
