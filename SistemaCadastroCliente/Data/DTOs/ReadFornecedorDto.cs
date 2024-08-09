using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroCliente.Data.DTOs
{
    public class ReadFornecedorDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Segmento { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public IFormFile Foto { get; set; }
    }
}
