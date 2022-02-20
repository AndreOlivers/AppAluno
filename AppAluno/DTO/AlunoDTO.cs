using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.DTO
{
    public class AlunoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Aluno")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Sobrenome do Aluno")]
        public string Sobrenome { get; set; }
        [Required]
        [Display(Name = "Matrícula do Aluno")]
        public string Matricula { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public string Curso { get; set; }
    }
}
