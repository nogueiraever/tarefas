using Tarefas.Dominio;

namespace Tarefas.Infra.Dtos
{
    public class ListarTarefaDto : TarefaDto
    {
        public StatusTarefa Status { get; set; }
    }
}