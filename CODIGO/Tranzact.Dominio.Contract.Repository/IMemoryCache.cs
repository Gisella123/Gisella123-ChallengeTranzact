namespace Tranzact.Dominio.Contract.Repository
{
    public interface IMemoryCache
    {
        bool TryGetValue<TValorCache>(string clave, out TValorCache valor);

        void SetValue<TValorCache>(string clave, TValorCache valor);
    }
}
