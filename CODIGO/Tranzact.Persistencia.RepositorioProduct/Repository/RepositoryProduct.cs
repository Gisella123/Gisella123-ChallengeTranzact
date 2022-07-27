using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Dominio.Contract.Repository;
using Tranzact.Dominio.Entity;
using Tranzact.Persistencia.Repository;

namespace Tranzact.Persistencia.RepositorioProduct.Repository
{
    public class RepositoryProduct: RepositoryGenericEF<AppDBTranzactContext, Products>, IRepositoryProduct
    {
        private readonly AppDBTranzactContext _contexto;
        //private readonly IMemoryCache _cacheHelper;
        public RepositoryProduct(AppDBTranzactContext context /*, IMemoryCache cacheHelper*/ ) : base(context)
        {
            _contexto = context;
            //_cacheHelper = cacheHelper;
        }

    }    
}
