using AppAluno.Context;
using AppAluno.Interface;
using AppAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Serviço
{
    public class LoginService : ILogin
    {

        private readonly AppDbContext _context;
        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AutenticaUsuario(string loginUsuario, string senhaUsuario)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == u.Email && u.Senha == u.Senha);
        }
    }
}
