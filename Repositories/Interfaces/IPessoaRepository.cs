using CrudPessoa.Models;

namespace CrudPessoa.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
         Task<IEnumerable<Pessoa>> GetAllAsync();
         Task<Pessoa> GetByIdAsync(int id);
         Task AddAsync(Pessoa pessoa);
        Task UpdateAsync(Pessoa pessoa);
        Task DeleteAsync(int id);
    }
}