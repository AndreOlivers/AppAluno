using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
