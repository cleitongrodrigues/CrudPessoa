using CrudPessoa.Models;
using CrudPessoa.Repositories.Interfaces;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _repository;

    public PessoaService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PessoaResponseDTO>> GetAllAsync()
    {
        var pessoas = await _repository.GetAllAsync();

        return pessoas.Select(p => new PessoaResponseDTO
        {
           Id = p.Id,
           Nome = p.Nome,
           DT_Nascimento = p.DT_Nascimento 
        });
    }

    public async Task<PessoaResponseDTO?> GetByIdAsync(int id)
    {
        var pessoa = await _repository.GetByIdAsync(id);
        if (pessoa == null) return null;

        return new PessoaResponseDTO
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            DT_Nascimento = pessoa.DT_Nascimento
        };
    }

    public async Task AddAsync(PessoaCreateDTO pessoa)
    {
        var newPessoa = new Pessoa
        {
            Nome = pessoa.Nome,
            DT_Nascimento = pessoa.DT_Nascimento
        };
        await _repository.AddAsync(newPessoa);
    }

    public async Task UpdateAsync(PessoaUpdateDTO pessoa)
    {
        var existingPessoa = await _repository.GetByIdAsync(pessoa.Id);
        if (existingPessoa == null) return;

        existingPessoa.Nome = pessoa.Nome;
        existingPessoa.DT_Nascimento = pessoa.DT_Nascimento;

        await _repository.UpdateAsync(existingPessoa);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}