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
    /// Obtém os produtos da loja da marca Apple
    /// </summary>
    /// <returns> Nome e preço dos produtos Apple</returns>
    [HttpGet]
    public async Task<IActionResult> GetAppleList()
    {
        var valor =  await _storeService.GetAppleList();
        return Ok(valor);
    }
}
