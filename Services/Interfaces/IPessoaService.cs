using CrudPessoa.Models;

public interface IPessoaService
{
    Task<IEnumerable<PessoaResponseDTO>> GetAllAsync();
    Task<PessoaResponseDTO?> GetByIdAsync(int id);
    Task AddAsync(PessoaCreateDTO pessoa);
    Task UpdateAsync(PessoaUpdateDTO pessoa);
    Task DeleteAsync(int id);
}