using System;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.Dominio.Contract.Repository;

namespace Tranzact.Dominio.Contract.Repository
{
    public interface IDBContext
    {
        IRepositoryProduct RepositoryProduct { get; }
        bool ValidarConexion();
        bool Commit();
    }
}
