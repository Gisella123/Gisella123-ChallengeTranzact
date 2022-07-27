using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Dominio.Entity;

namespace Tranzact.Dominio.Contract.Repository
{
    public interface IRepositoryProduct : IRepositoryGenericEF<Products>
    {
    }
}
