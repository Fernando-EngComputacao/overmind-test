using Teste.Models.Apple;
using Teste.Models.Device;

namespace Teste.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<Apple>> GetAppleList();
        Task<List<Device>> GetDeviceList();
        Task<List<Apple>> GetAppleListToDebug();
    }
}
