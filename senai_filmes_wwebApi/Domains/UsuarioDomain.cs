using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo de senha precisa ter no minimo 5 e no máximo 20 caracteres")]
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}
