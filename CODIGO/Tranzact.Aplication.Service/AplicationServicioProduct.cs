using Tranzact.Aplication.Contract;
using Tranzact.Aplication.DTO;
using Tranzact.Dominio.Contract.Repository;
using Tranzact.Dominio.Entity;
using Tranzact.Infraestruture;
using Tranzact.Persistencia.RepositorioProduct;

namespace Tranzact.Aplication.Service
{
    public class AplicationServicioProduct : IAplicationServicioProduct
    {
        IDBContext _unitOfWork;
        ILogger _logger;
        public AplicationServicioProduct(AppDBTranzactContext unitOfWork, ILogger logger) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;   
        }
        public ProductDTO? Get(int id)
        {
            var product = _unitOfWork.RepositoryProduct.Get(f => f.Id == id).FirstOrDefault();

            if (product == null)
                return null;

            return new ProductDTO() 
            {
                Brand = product.Brand,
                ProductName = product.Name,
                Price = product.Price,
                Id =  product.Id
            };
        }

        public bool Insert(ProductInsertDTO productDTO)
        {
            var product = new Products()
            {
                Brand = productDTO.Brand,
                Price = productDTO.Price,
                Name = productDTO.ProductName
            };
            _unitOfWork.RepositoryProduct.Add(product);            
            return _unitOfWork.Commit();
        }

        public bool Update(ProductUpdateDTO productDTO, int Id)
        {
            if(_unitOfWork.RepositoryProduct.Get(f=> f.Id == Id) == null )
                return false;
            var product = new Products()
            {
                Brand = productDTO.Brand,
                Name = productDTO.ProductName,
                Price = productDTO.Price,
                Id = Id,
            };
            _unitOfWork.RepositoryProduct.Update(product);
            return _unitOfWork.Commit();
        }
    }
}
