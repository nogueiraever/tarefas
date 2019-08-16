using System.Collections.Generic;
using Tarefas.Infra.Dtos;

namespace Tarefas.Aplicacao
{
    public interface IManterTarefas
    {
        void Atualizar(TarefaDto tarefaDto);

        void Concluir(long id);

        void Criar(TarefaDto tarefaDto);

        IList<ListarTarefaDto> Listar();

        void Reativar(long id);

        void Remover(long id);
    }
}