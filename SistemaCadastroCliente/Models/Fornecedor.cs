using SistemaCadastroCliente.Roles;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroCliente.Models;
public class Fornecedor : UserModel
{

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

    public string FotoPath { get; set; }

    public Fornecedor()
    {
        UserRole = Role.Fornecedor; 
    }

}
