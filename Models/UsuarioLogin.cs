using System.ComponentModel.DataAnnotations;

namespace agenda_api.Models
{
    public class UsuarioLogin
    {   
        [Required(ErrorMessage = "Campo login é obrigatório!")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Campo senha é obrigatório!")]
        public string? Senha { get; set; }
    }
}