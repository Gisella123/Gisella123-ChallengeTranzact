
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.Dominio.Contract.Repository;
using Tranzact.Dominio.Entity;
using Tranzact.Persistencia.RepositorioProduct.Repository;

namespace Tranzact.Persistencia.RepositorioProduct
{
    public class AppDBTranzactContext : DbContext, IDBContext
    {
        public virtual DbSet<Products> Products { get; set; }
        public AppDBTranzactContext(DbContextOptions<AppDBTranzactContext> options/*, IMemoryCache cacheHelper*/)
            : base(options)
        {
            RepositoryProduct = new RepositoryProduct(this/*, cacheHelper*/);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>()
                .HasKey(p => new { p.Id });

        }
        public IRepositoryProduct RepositoryProduct { get; private set; }

        public bool ValidarConexion()
        {
            return Database.CanConnect();
        }

        public bool Commit()
        {
            return this.SaveChanges() > 0 ? true : false;
        }
        #region dispose
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
