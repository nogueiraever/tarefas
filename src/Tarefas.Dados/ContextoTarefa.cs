using Microsoft.EntityFrameworkCore;
using Tarefas.Dados.Mapeamentos;
using Tarefas.Dominio;

namespace Tarefas.Dados
{
    public class ContextoTarefa : DbContext
    {
        public ContextoTarefa(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoTarefa());

            base.OnModelCreating(modelBuilder);
        }
    }
}