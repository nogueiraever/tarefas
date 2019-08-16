using System.Linq;

namespace Tarefas.Dominio
{
    public interface IRepositorioBase<T> where T : Entidade
    {
        void Atualizar(T entidade);

        void Excluir(long id);

        void Inserir(T entidade);

        T ObterPorId(long id);

        IQueryable<T> ObterTodos();
    }
}