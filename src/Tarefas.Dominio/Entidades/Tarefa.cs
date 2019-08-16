using System;

namespace Tarefas.Dominio
{
    public class Tarefa : Entidade
    {
        public Tarefa()
        {
            Status = StatusTarefa.Novo;
        }

        public DateTime? DataConclusao { get; private set; }
        public DateTime? DataRemocao { get; private set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; private set; }
        public string Titulo { get; set; }

        public void Concluir()
        {
            if (Status != StatusTarefa.Novo)
            {
                throw new NegocioException("Só é possível concluir tarefas que estejam com status 'Novo'.");
            }
            Status = StatusTarefa.Concluido;
            DataConclusao = DateTime.Now;
        }

        public void Reativar()
        {
            if (Status != StatusTarefa.Concluido)
            {
                throw new NegocioException("Só é possível reativar tarefas que estejam com status 'Concluído'.");
            }
            Status = StatusTarefa.Novo;
            DataConclusao = null;
        }

        public void Remover()
        {
            if (Status != StatusTarefa.Novo)
            {
                throw new NegocioException("Só é possível remover tarefas que estejam com status 'Novo'.");
            }
            Status = StatusTarefa.Removido;
            DataRemocao = DateTime.Now;
        }
    }
}