using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_filmes_senai.DTO
{
    public class LoginDTO
    {

       
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }

        
        [Required(ErrorMessage = "O email é obrigatório!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no maximo 60")]
        public string? Senha { get; set; }

    }
}
