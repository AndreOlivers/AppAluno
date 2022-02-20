using AppAluno.Context;
using AppAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Serviço
{
    public class UsuarioService : IUsuario
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByName(string nome)
        {
            IEnumerable<Usuario> usuarios;
            if (!string.IsNullOrEmpty(nome))
            {
                usuarios = await _context.Usuario
                    .Where(u => u.Nome.Contains(nome))
                    .ToListAsync();
            }
            else
            {
                usuarios = await GetAll();
            }
            return usuarios;
        }

        public async Task<Usuario> GetId(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }
        public async Task Create(Usuario aluno)
        {
            _context.Usuario.Add(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Usuario aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Usuario aluno)
        {
            _context.Usuario.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
