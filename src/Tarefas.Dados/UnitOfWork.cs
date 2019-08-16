using System;
using Tarefas.Dominio.Repositorios;

namespace Tarefas.Dados
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoTarefa contextoTarefa;

        public UnitOfWork(ContextoTarefa contextoTarefa)
        {
            this.contextoTarefa = contextoTarefa ?? throw new ArgumentNullException(nameof(contextoTarefa));
        }

        public int SaveChanges()
        {
            return contextoTarefa.SaveChanges();
        }
    }
}