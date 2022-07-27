using Tranzact.Aplication.DTO;

namespace Tranzact.Aplication.Contract
{
    public interface IAplicationServicioProduct
    {
        ProductDTO? Get(int id);
        bool Update(ProductUpdateDTO productDTO, int Id);
        bool Insert(ProductInsertDTO productDTO);
    }
}
