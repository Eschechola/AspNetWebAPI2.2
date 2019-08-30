using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome deve ser inserido")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no máximo 80 caracteres")]
        [RegularExpression(@"^[ a-zA-Z á]*$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha deve ser inserido")]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        [MaxLength(80, ErrorMessage = "A senha deve conter no máximo 80 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O email deve ser inserido")]
        [MinLength(10, ErrorMessage = "O email deve conter no mínimo 10 caracteres")]
        [MaxLength(150, ErrorMessage = "O email deve conter no máximo 80 caracteres")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O Email é inválido, insira outro.")]
        public string Email { get; set; }
    }
}
