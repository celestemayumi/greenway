using greenway2.DTOs;
using greenway2.Repositories;

namespace greenway2.Services
{
    public class HistoricoService
    {
        private readonly IGenericRepository<HistoricoDTO> _historicoRepository;

        public HistoricoService(IGenericRepository<HistoricoDTO> historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public async Task<IEnumerable<HistoricoDTO>> GetAllHistoricosAsync()
        {
            return await _historicoRepository.GetAllAsync();
        }
    }
}
