using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaCadastroCliente.Data;
using SistemaCadastroCliente.Data.DTOs;
using SistemaCadastroCliente.Models;
using System.Security.Claims;

namespace SistemaCadastroCliente.Services
{
    public class FornecedorService
    {
        private SistemaCadastroClienteContext _context;
        private IMapper _mapper;
        private UserManager<UserModel> _userManager;
        private UsuarioService _usuarioService;
        private IHttpContextAccessor _contextAccessor;

        public FornecedorService(SistemaCadastroClienteContext context, IMapper mapper, UserManager<UserModel> userManager, UsuarioService usuarioService, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _usuarioService = usuarioService;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedoresAsync()
        {
            var fornecedores = await _context.Fornecedores.ToListAsync();

            return fornecedores;
        }

        public Fornecedor GetFornecedorById(int id)
        {
            var fornecedor = _context.Fornecedores.FirstOrDefault(f => f.Id.Equals(id));
            if (fornecedor is null) throw new ArgumentNullException();

            return fornecedor;
        }


        public async Task<IEnumerable<ReadFornecedorDto>> SearchByNameAsync(string name)
        {
            var fornecedores = await _context.Fornecedores
                             .Where(f => f.Nome.Contains(name))
                             .ToListAsync();
            var fornecedoresDto = _mapper.Map<IEnumerable<ReadFornecedorDto>>(fornecedores);
            return fornecedoresDto;
        }

        public UserModel GetLoggedInUser()
        {
            var nomeUsuario = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name))?.Value;

            if (string.IsNullOrEmpty(nomeUsuario))
            {
                return null;
            }

            var usuarioFornecedor = _context.Fornecedores.FirstOrDefault(u => u.UserName.Equals(nomeUsuario));
            if (usuarioFornecedor is null)
            {
                var usuarioAdm = _context.Admins.FirstOrDefault(u => u.UserName.Equals(nomeUsuario));
                return usuarioAdm;
            }

            return usuarioFornecedor;
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            var fornecedorNoBanco = _context.Fornecedores.FirstOrDefault(f => f.Id == fornecedor.Id);
            
            if(fornecedor.Nome is not null)
            {
                fornecedorNoBanco.Nome = fornecedor.Nome;
            }
            if (fornecedor.CNPJ is not null)
            {
                fornecedorNoBanco.CNPJ = fornecedor.CNPJ;
            }
            if (fornecedor.Segmento is not null)
            {
                fornecedorNoBanco.Segmento = fornecedor.Segmento;
            }
            if (fornecedor.CEP is not null)
            {
                fornecedorNoBanco.CEP = fornecedor.CEP;
            }
            if(fornecedor.Endereco is not null)
            {
                fornecedorNoBanco.Endereco = fornecedor.Endereco;
            }
            _context.SaveChanges(); 
        }

        public void DeletarFornecedor(string id)
        {
            var fornecedor = _context.Fornecedores.FirstOrDefault(f => f.Id.Equals(id));
            if (fornecedor == null) throw new KeyNotFoundException("Fornecedor não encontrado.");

            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();
        }
    }
}
