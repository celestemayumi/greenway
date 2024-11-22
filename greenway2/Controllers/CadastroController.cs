using greenway2.DTOs;
using Microsoft.AspNetCore.Mvc;

public class CadastroController : Controller
{
    private readonly CadastroService _cadastroService;
    public CadastroController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var cadastros = await _cadastroService.GetAllAsync();
        return View(cadastros);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var cadastroDto = await _cadastroService.GetByIdAsync(id);
        if (cadastroDto == null)
        {
            return NotFound(); 
        }

        return View(cadastroDto); 
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, CadastroDTO cadastroDto)
    {
        if (id != cadastroDto.Id)
        {
            return BadRequest(); 
        }

        if (ModelState.IsValid)
        {

            var cadastroExistente = await _cadastroService.GetByIdAsync(id);
            if (cadastroExistente != null)
            {
                cadastroDto.IdLogin = cadastroExistente.IdLogin; 
                await _cadastroService.UpdateCadastroAsync(cadastroDto);
                return RedirectToAction(nameof(Index)); 
            }
        }

        return View(cadastroDto); 
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cadastroDto = await _cadastroService.GetByIdAsync(id);
        if (cadastroDto == null)
        {
            return NotFound();
        }

        return View(cadastroDto); 
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _cadastroService.DeleteCadastroAsync(id);
        return RedirectToAction(nameof(Index)); 
    }
}
