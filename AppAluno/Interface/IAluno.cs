using AppAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno
{
    public interface IAluno
    {
        Task <Aluno> GetId(int id );
        Task<IEnumerable<Aluno>> GetAll();
        Task<IEnumerable<Aluno>> GetByName(string nome);
        Task Create(Aluno aluno);
        Task Update(Aluno aluno);
        Task Delete(Aluno aluno);
    }
}
