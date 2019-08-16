using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tarefas.Dominio;

namespace Tarefas.Dados.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : Entidade
    {
        private readonly DbSet<T> dbSet;

        public RepositorioBase(ContextoTarefa contextoTarefa)
        {
            dbSet = contextoTarefa.Set<T>();
        }

        public void Atualizar(T entidade)
        {
            entidade.DataUltimaAlteracao = DateTime.Now;
            dbSet.Update(entidade);
        }

        public void Excluir(long id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public void Inserir(T entidade)
        {
            dbSet.Add(entidade);
        }

        public T ObterPorId(long id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> ObterTodos()
        {
            return dbSet;
        }
    }
}