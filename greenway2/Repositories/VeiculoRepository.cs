using greenway2.DTOs;
using greenway2.Models;
using Microsoft.EntityFrameworkCore;
using greenway2.Infrastructure;


namespace greenway2.Repositories
{
    public class VeiculoRepository : IGenericRepository<VeiculoDTO>
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VeiculoDTO>> GetAllAsync()
        {
            return await _context.Set<Veiculo>()
                .Select(v => new VeiculoDTO
                {
                    Id = v.Id,
                    NumeroSerie = v.NumeroSerie,
                    Latitude = v.Latitude,
                    Longitude = v.Longitude,
                    TipoVeiculo = v.TipoVeiculo
                })
                .ToListAsync();
        }

        public async Task<VeiculoDTO> GetByIdAsync(int id)
        {
            var veiculo = await _context.Set<Veiculo>().FindAsync(id);
            if (veiculo == null) return null;

            return new VeiculoDTO
            {
                Id = veiculo.Id,
                NumeroSerie = veiculo.NumeroSerie,
                Latitude = veiculo.Latitude,
                Longitude = veiculo.Longitude,
                TipoVeiculo = veiculo.TipoVeiculo
            };
        }

        public async Task AddAsync(VeiculoDTO dto)
        {
            var veiculo = new Veiculo
            {
                NumeroSerie = dto.NumeroSerie,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                TipoVeiculo = dto.TipoVeiculo
            };

            _context.Set<Veiculo>().Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VeiculoDTO dto)
        {
            var veiculo = await _context.Set<Veiculo>().FindAsync(dto.Id);
            if (veiculo == null) throw new Exception("Veículo não encontrado.");

            veiculo.NumeroSerie = dto.NumeroSerie;
            veiculo.Latitude = dto.Latitude;
            veiculo.Longitude = dto.Longitude;
            veiculo.TipoVeiculo = dto.TipoVeiculo;

            _context.Set<Veiculo>().Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var veiculo = await _context.Set<Veiculo>().FindAsync(id);
            if (veiculo == null) throw new Exception("Veículo não encontrado.");

            _context.Set<Veiculo>().Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
