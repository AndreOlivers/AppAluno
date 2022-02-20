using AppAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Interface
{
    public interface ILogin
    {
        public Task<Usuario> AutenticaUsuario(string loginUsuario, string senhaUsuario);
    }
}
