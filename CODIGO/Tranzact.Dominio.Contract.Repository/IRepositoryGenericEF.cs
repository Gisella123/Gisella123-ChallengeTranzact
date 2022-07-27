using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tranzact.Dominio.Contract.Repository
{
    public interface IRepositoryGenericEF<TEntidad> : IDisposable
        where TEntidad : class
    {
        IQueryable<TEntidad> Get(Expression<Func<TEntidad, bool>> predicado = null);
        void Add(TEntidad entity);
        void Delete(TEntidad entity);
        void Update(TEntidad entity);
    }
}
