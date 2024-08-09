using SistemaCadastroCliente.Roles;

namespace SistemaCadastroCliente.Models
{
    public class Admin : UserModel
    {
        public Admin()
        {
            UserRole = Role.Admin;
        }


    }
}
