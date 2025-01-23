using Microsoft.AspNetCore.Mvc;
using Teste.Services.Interfaces;

namespace Teste.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    /// <summary>
    /// Obtém os produtos da loja da marca Apple e gera CSV, incluso produtos com valores 0
    /// </summary>
    /// <returns> Nome e preço dos produtos Apple</returns>
    [HttpGet("list/apple")]
    public async Task<IActionResult> GetAppleList()
    {
        var appleList =  await _storeService.GetAppleList();
        return Ok(appleList);
    }

    /// <summary>
    /// Obtém os produtos da loja de todas as marcas
    /// </summary>
    /// <returns> Dados gerais dos produtos das lojas</returns>
    [HttpGet("list/device")]
    public async Task<IActionResult> GetDevices()
    {
        var deviceList = await _storeService.GetDeviceList();
        return Ok(deviceList);
    }
}
