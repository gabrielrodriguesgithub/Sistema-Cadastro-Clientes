using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroCliente.Data.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
