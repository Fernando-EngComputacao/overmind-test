using Teste.Client.Interfaces;
using Teste.Config.Interface;
using Teste.Models;
using Teste.Models.Device;
using Teste.Services.Interfaces;

namespace Teste.Services
{
    public class StoreService : IStoreService
    {
        
        private readonly IClientDevices _clientDevice;

        public StoreService( IClientDevices clientDevice)
        {
            _clientDevice = clientDevice;
        }

        public async Task<List<Apple>> GetAppleList() => await _clientDevice.GetAppleList();

        public async Task<List<Device>> GetDeviceList() => await _clientDevice.GetDeviceList();

        
    }
}
