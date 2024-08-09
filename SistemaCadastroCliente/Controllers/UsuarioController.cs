using Microsoft.AspNetCore.Mvc;
using SistemaCadastroCliente.Data.DTOs;
using SistemaCadastroCliente.Models;
using SistemaCadastroCliente.Roles;
using SistemaCadastroCliente.Services;
using System.Diagnostics;

namespace SistemaCadastroCliente.Controllers
{
    
    [Route("[Controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioService _usuarioService;
        private FornecedorService _fornecedorService;

        public UsuarioController(UsuarioService usuarioService, FornecedorService fornecedorService)
        {
            _usuarioService = usuarioService;
            _fornecedorService = fornecedorService;
        }

        [HttpGet("RegisterAdm")]
        public IActionResult CadastraAdminDto()
        {
            return View("Register");
        }

        [HttpPost("RegisterAdm")]
        public async Task<IActionResult> CadastraAdminDto(CreateAdminDto dto)
        {
            await _usuarioService.CadastraAdminDto(dto);
           return RedirectToAction("Index", "Home");
        }

        [HttpGet("Register")]
        public IActionResult CadastraFornecedorDto()
        {
            return View("Register");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CadastraFornecedorDto(CreateFornecedorDto dto)
        {
            if (dto.Foto != null && dto.Foto.Length > 0)
            {
                
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var filePath = Path.Combine(uploadsFolder, Path.GetFileName(dto.Foto.FileName));

                
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Foto.CopyToAsync(stream);
                }

                dto.FotoPath = $"/uploads/{Path.GetFileName(dto.Foto.FileName)}";
            }
            await _usuarioService.CadastraFornecedorDto(dto);
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("Login")]
        public async Task<IActionResult>Login(LoginDto dto)
        {
            var token = await _usuarioService.Login(dto);
            
            var user = _fornecedorService.GetLoggedInUser();

            if (token is null || user is null) return BadRequest("Falha na autenticação");

            if (user.UserRole == Role.Admin) 
            {
                return Json(new { token, redirectUrl = "/Fornecedor/ListDetails"  });
            }

            else if (user.UserRole == Role.Fornecedor) 
            {
                return Json(new { token, redirectUrl = "Fornecedor/Details" });
            }
            return Json(new { token, redirectUrl = "Fornecedor/Details" });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _usuarioService.Logout();
            return NoContent();
        }
    }
}
