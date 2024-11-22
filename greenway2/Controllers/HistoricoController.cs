using greenway2.Services;
using Microsoft.AspNetCore.Mvc;

namespace greenway2.Controllers
{
    [Route("historicos")]
    public class HistoricoController : Controller
    {
        private readonly HistoricoService _historicoService;

        public HistoricoController(HistoricoService historicoService)
        {
            _historicoService = historicoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var historicos = await _historicoService.GetAllHistoricosAsync();
            return View(historicos);
        }
    }
}
