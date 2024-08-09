using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroCliente.Data.DTOs
{
    public class CreateFornecedorDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }


        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"\d{14}")]
        public string CNPJ { get; set; }

        [Required]
        public string Segmento { get; set; }

        [Required]
        [RegularExpression(@"\d{8}")]
        public string CEP { get; set; }

        [MaxLength(255)]
        public string Endereco { get; set; }

        public IFormFile Foto { get; set; }
        public string FotoPath { get; set; }
    }
}
