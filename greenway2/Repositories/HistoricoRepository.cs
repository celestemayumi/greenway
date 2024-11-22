using Microsoft.EntityFrameworkCore;
using greenway2.DTOs;
using greenway2.Models;
using greenway2.Infrastructure;

namespace greenway2.Repositories
{
    public class HistoricoRepository : IGenericRepository<HistoricoDTO>
    {
        private readonly AppDbContext _context;

        public HistoricoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoDTO>> GetAllAsync()
        {
            return await _context.Historicos
                .Include(h => h.Cadastro) 
                .Include(h => h.Veiculo) 
                .Select(h => new HistoricoDTO
                {
                    Id = h.Id,
                    DataUso = h.DataUso,
                    LocalPartida = h.LocalPartida,
                    LocalDestino = h.LocalDestino,
                    TempoViagem = h.TempoViagem,
                    Percurso = h.Percurso,
                    IdCadastro = h.IdCadastro,
                    IdVeiculo = h.IdVeiculo,
                })
                .ToListAsync();
        }

        public async Task<HistoricoDTO> GetByIdAsync(int id)
        {
            return await _context.Historicos
                .Where(h => h.Id == id)
                .Include(h => h.Cadastro)
                .Include(h => h.Veiculo)
                .Select(h => new HistoricoDTO
                {
                    Id = h.Id,
                    DataUso = h.DataUso,
                    LocalPartida = h.LocalPartida,
                    LocalDestino = h.LocalDestino,
                    TempoViagem = h.TempoViagem,
                    Percurso = h.Percurso,
                    IdCadastro = h.IdCadastro,
                    IdVeiculo = h.IdVeiculo
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(HistoricoDTO dto)
        {
            var historico = new Historico
            {
                DataUso = dto.DataUso,
                LocalPartida = dto.LocalPartida,
                LocalDestino = dto.LocalDestino,
                TempoViagem = dto.TempoViagem,
                Percurso = dto.Percurso,
                IdCadastro = dto.IdCadastro,
                IdVeiculo = dto.IdVeiculo
            };

            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistoricoDTO dto)
        {
            var historico = await _context.Historicos.FindAsync(dto.Id);
            if (historico != null)
            {
                historico.DataUso = dto.DataUso;
                historico.LocalPartida = dto.LocalPartida;
                historico.LocalDestino = dto.LocalDestino;
                historico.TempoViagem = dto.TempoViagem;
                historico.Percurso = dto.Percurso;
                historico.IdCadastro = dto.IdCadastro;
                historico.IdVeiculo = dto.IdVeiculo;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var historico = await _context.Historicos.FindAsync(id);
            if (historico != null)
            {
                _context.Historicos.Remove(historico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
