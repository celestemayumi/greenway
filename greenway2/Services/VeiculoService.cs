using greenway2.DTOs;
using greenway2.Repositories;

namespace greenway2.Services
{
    public class VeiculoService
    {
        private readonly VeiculoRepository _veiculoRepository;

        public VeiculoService(VeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<VeiculoDTO>> GetVeiculosAsync()
        {
            return await _veiculoRepository.GetAllAsync();
        }

        public async Task<VeiculoDTO> GetVeiculoByIdAsync(int id)
        {
            return await _veiculoRepository.GetByIdAsync(id);
        }

        public async Task AddVeiculoAsync(VeiculoDTO veiculoDto)
        {
            await _veiculoRepository.AddAsync(veiculoDto);
        }

        public async Task UpdateVeiculoAsync(VeiculoDTO veiculoDto)
        {
            await _veiculoRepository.UpdateAsync(veiculoDto);
        }

        public async Task DeleteVeiculoAsync(int id)
        {
            await _veiculoRepository.DeleteAsync(id);
        }
    }
}
