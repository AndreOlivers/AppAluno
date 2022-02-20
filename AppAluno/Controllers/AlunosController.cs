using AppAluno.Models;
using AppAluno.Serviço;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAluno _alunoService;
        public AlunosController(IAluno alunoService)
        {
            _alunoService = alunoService;
        }

        // GET api/<AlunosController>/5

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> BuscarAlunoId(int id)
        {
            try
            {
                var alunos = await _alunoService.GetId(id);
                if (alunos == null)
                    return NotFound($"Não existem alunos com o este id = {id}");

                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Aluno não encontrado");
            }
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetAlunos()
        {
            try
            {
                var usuarios = await _alunoService.GetAll();
                return Ok(usuarios);
            }
            catch
            {
                //RETURN BADREQUEST("REQUEST INVÁLIDO")
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Aluno");
            }
        }
        // POST api/<AlunosController>
        [HttpPost]
        public async Task<ActionResult> AdicionarAluno(Aluno aluno)
        {
            try
            {
                await _alunoService.Create(aluno);
                return CreatedAtRoute(nameof(GetAlunos), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Erro ao Cadastrar um Aluno");
            }
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno != null)
                {
                    await _alunoService.Update(aluno);
                    return Ok($"Aluno Atualizado com sucesso");
                }
                else
                {
                    return NotFound($"Aluno com id:{id} não atualizado");
                }
            }
            catch
            {
                return BadRequest($"Aluno não encontrado");
            }
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetId(id);
                if (aluno != null)
                {
                    await _alunoService.Delete(aluno);
                    return Ok($"Aluno de id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Aluno com id={id} não encontrado");
                }
            }

            catch (Exception e)
            {
                return BadRequest("Aluno não encontrado");
            }
        }
    }
}
