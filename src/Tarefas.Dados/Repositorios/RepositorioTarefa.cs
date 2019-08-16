using Tarefas.Dados.Repositorios;
using Tarefas.Dominio;

namespace Tarefas.Dados
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefa(ContextoTarefa contextoTarefa) : base(contextoTarefa)
        {
        }
    }
}