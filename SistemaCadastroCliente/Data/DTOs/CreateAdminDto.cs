using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroCliente.Data.DTOs
{
    public class CreateAdminDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
