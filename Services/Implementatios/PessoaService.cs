using CrudPessoa.Models;
using CrudPessoa.Repositories.Interfaces;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _repository;

    public PessoaService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Pessoa>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Pessoa?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Pessoa pessoa)
    {
        await _repository.AddAsync(pessoa);
    }

    public async Task UpdateAsync(Pessoa pessoa)
    {
        await _repository.UpdateAsync(pessoa);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}