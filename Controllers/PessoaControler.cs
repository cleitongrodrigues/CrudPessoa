using CrudPessoa.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudPessoa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaResponseDTO>>> Get()
        {
            var pessoas = await _pessoaService.GetAllAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaResponseDTO>> GetById(int id)
        {
            var pessoa = await _pessoaService.GetByIdAsync(id);
            if (pessoa == null)
            {
                return NotFound($"Pessoa com ID {id} não encontrada.");
            }

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PessoaCreateDTO pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Dados da pessoa são inválidos.");
            }

            await _pessoaService.AddAsync(pessoa);
            return Ok("Pessoa criada com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PessoaUpdateDTO pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest("ID da pessoa não corresponde ao ID fornecido.");
            }

            await _pessoaService.UpdateAsync(pessoa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pessoaService.DeleteAsync(id);
            return NoContent();
        }
    }
}