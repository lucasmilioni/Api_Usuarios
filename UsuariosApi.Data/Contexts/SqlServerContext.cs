using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Mappings;

namespace UsuariosApi.Data.Contexts
{
    /// <summary>
    /// Classe para conexão com o BD e contexto do EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //método para adicionar a connectionstring do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDUsuariosApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //método para adicionar cada classe de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new HistoricoMap());
        }

        //propriedades do tipo DbSet para cada entidade
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Perfil>? Perfil { get; set; }
        public DbSet<Historico> Historico { get; set; }
    }
}


