using AppAluno.Context;
using AppAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Serviço
{
    public class AlunoService : IAluno
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetId(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetByName(string nome)
        {
            IEnumerable<Aluno> alunos;
            if (!string.IsNullOrEmpty(nome))
            {
                alunos = await _context.Aluno
                    .Where(u => u.Nome.Contains(nome))
                    .ToListAsync();
            }
            else
            {
                alunos = await GetAll();
            }
            return alunos;
        }

        public async Task Create(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Aluno aluno)
        {
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
