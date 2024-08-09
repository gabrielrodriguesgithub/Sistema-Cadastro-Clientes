using AutoMapper;
using SistemaCadastroCliente.Data.DTOs;
using SistemaCadastroCliente.Models;

namespace SistemaCadastroCliente.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CreateFornecedorDto, Fornecedor>();
            CreateMap<CreateAdminDto, Admin>();
            CreateMap<Fornecedor, ReadFornecedorDto>();

        }
    }
}
