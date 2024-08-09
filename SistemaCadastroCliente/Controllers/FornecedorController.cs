using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroCliente.Data.DTOs;
using SistemaCadastroCliente.Models;
using SistemaCadastroCliente.Services;

namespace SistemaCadastroCliente.Controllers
{
    [Route("[Controller]")]
    public class FornecedorController : Controller
    {
        private FornecedorService _fornecedorService;
        private IMapper _mapper;

        public FornecedorController(FornecedorService fornecedorService, IMapper mapper)
        {
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        [HttpGet("ListDetails")]
        public async Task<IActionResult> GetFornecedoresAsync()
        {
            var fornecedores = await _fornecedorService.GetFornecedoresAsync();
            return View("ListDetails" ,fornecedores);
        }

        [HttpGet("Details")]
        public IActionResult GetLoggedInUser()
        {
            var fornecedor = _fornecedorService.GetLoggedInUser();

            if (fornecedor is null)
            {
                return Unauthorized();
            }

            return View("Details", fornecedor);
        }


        [HttpGet("FornecedorNome")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var fornecedores = await _fornecedorService.SearchByNameAsync(name);
            return View("Index", fornecedores);
        }

        [HttpPut("Details")]
        public IActionResult AtualizarFornecedor([FromBody] Fornecedor fornecedor)
        {
            _fornecedorService.UpdateFornecedor(fornecedor);
            return Ok(fornecedor);
        }

        [HttpDelete("Details/{id}")]
        public IActionResult DeletarFornecedor(string id)
        {
            _fornecedorService.DeletarFornecedor(id);

            return NoContent();
        }

    }
}
