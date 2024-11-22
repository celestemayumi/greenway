using greenway2.DTOs;
using greenway2.Repositories;

namespace greenway2.Services
{
    public class LoginService
    {
        private readonly IGenericRepository<LoginDTO> _loginRepository;

        public LoginService(IGenericRepository<LoginDTO> loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<IEnumerable<LoginDTO>> GetAllLoginsAsync()
        {
            return await _loginRepository.GetAllAsync();
        }

        public async Task<LoginDTO> GetLoginByIdAsync(int id)
        {
            return await _loginRepository.GetByIdAsync(id);
        }

        public async Task AddLoginAsync(LoginDTO loginDto)
        {
            await _loginRepository.AddAsync(loginDto);
        }

        public async Task UpdateLoginAsync(LoginDTO loginDto)
        {
            await _loginRepository.UpdateAsync(loginDto);
        }

        public async Task DeleteLoginAsync(int id)
        {
            await _loginRepository.DeleteAsync(id);
        }
    }
}
