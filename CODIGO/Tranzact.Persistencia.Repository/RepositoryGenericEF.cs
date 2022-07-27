using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tranzact.Dominio.Contract.Repository;

namespace Tranzact.Persistencia.Repository
{
    public class RepositoryGenericEF<TContexto, TEntidad> :
        IRepositoryGenericEF<TEntidad>
        where TEntidad : class
        where TContexto : DbContext
    {        protected readonly TContexto _contexto;

        public RepositoryGenericEF(TContexto context)
        {
            _contexto = context;
        }

        public IQueryable<TEntidad> Get(Expression<Func<TEntidad, bool>> predicado = null)
        {
            IQueryable<TEntidad> query = _contexto.Set<TEntidad>();
            if (predicado != null) query = query.Where(predicado);
            foreach (var property in _contexto.Model.FindEntityType(typeof(TEntidad)).GetNavigations())
                query = query.Include(property.Name);

            return query;
        }

        public void Add(TEntidad entity)
        {
            _contexto.Set<TEntidad>().Add(entity);
        }

        public void Update(TEntidad entidad)
        {
            _contexto.Entry(entidad).State = EntityState.Modified;
        }

        public void Delete(TEntidad entidad)
        {
            _contexto.Set<TEntidad>().Remove(entidad);
        }


        #region IDisposable Support

        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _contexto.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~RepositoryGenericEF()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
