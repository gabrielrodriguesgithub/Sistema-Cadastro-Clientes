using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using SistemaCadastroCliente.Data;
using SistemaCadastroCliente.Data.DTOs;
using SistemaCadastroCliente.Models;
using System.Security.Claims;

namespace SistemaCadastroCliente.Services
{
    public class UsuarioService
    {
        private SistemaCadastroClienteContext _context;
        private IMapper _mapper;
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(SistemaCadastroClienteContext context, IMapper mapper, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, TokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task CadastraAdminDto(CreateAdminDto dto)
        {
            Admin usuario = _mapper.Map<Admin>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }

            Console.WriteLine("Usuario admin cadastrado!");
        }

        public async Task CadastraFornecedorDto(CreateFornecedorDto dto)
        {
            Fornecedor usuario = _mapper.Map<Fornecedor>(dto);

            usuario.FotoPath = dto.FotoPath;

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
            Console.WriteLine("Usuário fornecedor cadastrado!");
        }

        public async Task<string> Login(LoginDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            Console.WriteLine("Usuario Logado!");
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(u => u.UserName.Equals(dto.Username));

            var token = _tokenService.GerarToken(usuario);

            return token;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
