using Teste.Models.Device;

namespace Teste.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<Device>> ObterProdutos();
    }
}
