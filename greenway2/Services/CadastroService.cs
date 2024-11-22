using greenway2.DTOs;
using greenway2.Repositories;

public class CadastroService
{
    private readonly IGenericRepository<CadastroDTO> _cadastroRepository;

    public CadastroService(IGenericRepository<CadastroDTO> cadastroRepository)
    {
        _cadastroRepository = cadastroRepository;
    }

    public async Task<IEnumerable<CadastroDTO>> GetAllAsync()
    {
        return await _cadastroRepository.GetAllAsync();
    }

    public async Task<CadastroDTO> GetByIdAsync(int id)
    {
        return await _cadastroRepository.GetByIdAsync(id);
    }

    public async Task UpdateCadastroAsync(CadastroDTO cadastroDto)
    {

        var cadastroExistente = await _cadastroRepository.GetByIdAsync(cadastroDto.Id);
        if (cadastroExistente != null)
        {
            cadastroDto.IdLogin = cadastroExistente.IdLogin; 
            await _cadastroRepository.UpdateAsync(cadastroDto);
        }
    }

    public async Task DeleteCadastroAsync(int id)
    {
        await _cadastroRepository.DeleteAsync(id);
    }
}