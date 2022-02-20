using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAluno.ViewModel
{
    public class UsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Digite o seu Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Digite o seu Sobrenome")]
        public string Sobrenome { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        [Display(Name = "Digite o seu email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }
    }
}
