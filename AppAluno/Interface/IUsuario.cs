using AppAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Serviço
{
    public interface IUsuario
    {
        Task<Usuario> GetId(int id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> GetByName(string nome);
        Task Create(Usuario aluno);
        Task Update(Usuario aluno);
        Task Delete(Usuario aluno);
    }
}
