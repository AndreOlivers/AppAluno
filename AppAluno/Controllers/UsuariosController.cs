using AppAluno.Models;
using AppAluno.Serviço;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _usuarioService;
        public UsuariosController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> BuscarAlunoId(int id)
        {
            try
            {
                var usuarios = await _usuarioService.GetId(id);
                if (usuarios == null)
                    return NotFound($"Não existem usuarios com o este id = {id}");

                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Usuario não encontrado");
            }
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetAll();
                return Ok(usuarios);
            }
            catch
            {
                //RETURN BADREQUEST("REQUEST INVÁLIDO")
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuario");
            }
        }
        // POST api/<AlunosController>
        [HttpPost]
        public async Task<ActionResult> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                await _usuarioService.Create(usuario);
                return CreatedAtRoute(nameof(GetUsuarios), new { id = usuario.Id }, usuario);
            }
            catch
            {
                return BadRequest("Erro ao Cadastrar um usuário");
            }
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    await _usuarioService.Update(usuario);
                    return Ok($"Usuario Atualizado com sucesso");
                }
                else
                {
                    return NotFound($"Usuario com id:{id} não atualizado");
                }
            }
            catch
            {
                return BadRequest($"Usuario não encontrado");
            }
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetId(id);
                if (usuario != null)
                {
                    await _usuarioService.Delete(usuario);
                    return Ok($"Usuario de id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Usuario com id={id} não encontrado");
                }
            }

            catch (Exception e)
            {
                return BadRequest("Usuario não encontrado");
            }
        }
    }
}
