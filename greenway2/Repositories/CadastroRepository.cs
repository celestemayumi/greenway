using greenway2.DTOs;
using greenway2.Infrastructure;
using greenway2.Models;
using greenway2.Repositories;
using Microsoft.EntityFrameworkCore;


public class CadastroRepository : IGenericRepository<CadastroDTO>
{
    private readonly AppDbContext _context;

    public CadastroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CadastroDTO>> GetAllAsync()
    {
        return await _context.Cadastros
            .Select(c => new CadastroDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                NumeroRg = c.NumeroRg,
                NumeroCpf = c.NumeroCpf,
                Senha = c.Senha,
                IdLogin = c.IdLogin
            })
            .ToListAsync();
    }

    public async Task<CadastroDTO> GetByIdAsync(int id)
    {
        return await _context.Cadastros
            .Where(c => c.Id == id)
            .Select(c => new CadastroDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                NumeroRg = c.NumeroRg,
                NumeroCpf = c.NumeroCpf,
                Senha = c.Senha,
                IdLogin = c.IdLogin
            })
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(CadastroDTO dto)
    {
        var cadastro = new Cadastro
        {
            Nome = dto.Nome,
            Email = dto.Email,
            NumeroRg = dto.NumeroRg,
            NumeroCpf = dto.NumeroCpf,
            Senha = dto.Senha,
            IdLogin = dto.IdLogin
        };

        _context.Cadastros.Add(cadastro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CadastroDTO dto)
    {
        var cadastro = await _context.Cadastros.FindAsync(dto.Id);
        if (cadastro != null)
        {
            cadastro.Nome = dto.Nome;
            cadastro.Email = dto.Email;
            cadastro.NumeroRg = dto.NumeroRg;
            cadastro.NumeroCpf = dto.NumeroCpf;
            cadastro.Senha = dto.Senha;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var cadastro = await _context.Cadastros.FindAsync(id);
        if (cadastro != null)
        {
            _context.Cadastros.Remove(cadastro);
            await _context.SaveChangesAsync();
        }
    }
}
