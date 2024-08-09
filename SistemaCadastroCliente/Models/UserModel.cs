using Microsoft.AspNetCore.Identity;
using SistemaCadastroCliente.Roles;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SistemaCadastroCliente.Models;

public class UserModel : IdentityUser
{
        public Role UserRole { get; set; }

        public UserModel()
        {

        }
    }
