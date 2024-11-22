using Microsoft.EntityFrameworkCore;
using greenway2.DTOs;
using greenway2.Infrastructure;
using greenway2.Models;

namespace greenway2.Repositories
{
    public class LoginRepository : IGenericRepository<LoginDTO>
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoginDTO>> GetAllAsync()
        {
            return await _context.Logins
                .Select(l => new LoginDTO
                {
                    Id = l.Id,
                    Email = l.Email,
                    Senha = l.Senha
                })
                .ToListAsync();
        }

        public async Task<LoginDTO> GetByIdAsync(int id)
        {
            var login = await _context.Logins
                .Where(l => l.Id == id)
                .Select(l => new LoginDTO
                {
                    Id = l.Id,
                    Email = l.Email,
                    Senha = l.Senha
                })
                .FirstOrDefaultAsync();
            return login;
        }

        public async Task AddAsync(LoginDTO dto)
        {
            var login = new Login
            {
                Email = dto.Email,
                Senha = dto.Senha
            };

            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoginDTO dto)
        {
            var login = await _context.Logins.FindAsync(dto.Id);
            if (login != null)
            {
                login.Email = dto.Email;
                login.Senha = dto.Senha;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login != null)
            {
                _context.Logins.Remove(login);
                await _context.SaveChangesAsync();
            }
        }
    }
}
