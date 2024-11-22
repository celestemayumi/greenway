using greenway2.DTOs;
using greenway2.Services;
using Microsoft.AspNetCore.Mvc;

namespace greenway2.Controllers
{
    [Route("veiculos")]
    public class VeiculoController : Controller
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculoService.GetVeiculosAsync();
            return View(veiculos); 
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new VeiculoDTO()); 
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(VeiculoDTO veiculoDto)
        {
            if (ModelState.IsValid)
            {
                await _veiculoService.AddVeiculoAsync(veiculoDto);
                return RedirectToAction(nameof(Index));
            }

            return View(veiculoDto); 
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            // Busca o DTO do veículo
            var veiculoDto = await _veiculoService.GetVeiculoByIdAsync(id);
            if (veiculoDto == null)
            {
                return NotFound(); 
            }
            return View(veiculoDto);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, VeiculoDTO veiculoDto)
        {
            if (id != veiculoDto.Id)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                await _veiculoService.UpdateVeiculoAsync(veiculoDto);
                return RedirectToAction(nameof(Index)); 
            }
            return View(veiculoDto);
        }


        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            var veiculoDto = await _veiculoService.GetVeiculoByIdAsync(id);
            if (veiculoDto == null)
            {
                return NotFound(); 
            }
            return View(veiculoDto);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _veiculoService.DeleteVeiculoAsync(id);
            return RedirectToAction(nameof(Index)); 
        }

    }
}
