using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaCadastroCliente.Models;

namespace SistemaCadastroCliente.Data
{
    public class SistemaCadastroClienteContext : IdentityDbContext <UserModel>
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public SistemaCadastroClienteContext()
        {
            
        }

        public SistemaCadastroClienteContext(DbContextOptions options) : base(options)     
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
