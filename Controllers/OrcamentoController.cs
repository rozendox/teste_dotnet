using Microsoft.AspNetCore.Mvc;
using teste_dotnet.Services;

namespace teste_dotnet.Controllers;

// Controllers/OrcamentoController.cs

/// <summary>
/// Controller responsável pelos endpoints de orçamento.
/// </summary>

[ApiController]
[Route("api/orcamentos")]
public class OrcamentoController : ControllerBase
{
    private readonly OrcamentoService _service;

    public OrcamentoController(OrcamentoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarOrcamentoRequest request)
    {
        var (sucesso, erro, dados) = await _service.CriarAsync(request);

        if (!sucesso)
            return BadRequest(new { mensagem = erro });

        return CreatedAtAction(nameof(Criar), new { id = dados.Id }, dados);
    }
}
