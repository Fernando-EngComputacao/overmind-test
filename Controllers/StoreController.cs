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

    [HttpGet]
    public async Task<IActionResult> ObterProdutos()
    {
        var valor =  await _storeService.ObterProdutos();
        return Ok(valor);
    }
}
