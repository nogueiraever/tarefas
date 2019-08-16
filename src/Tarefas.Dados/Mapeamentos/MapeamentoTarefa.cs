using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Dominio;

namespace Tarefas.Dados.Mapeamentos
{
    public class MapeamentoTarefa : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
               .HasMaxLength(200);

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Status)
                .IsRequired();
        }
    }
}