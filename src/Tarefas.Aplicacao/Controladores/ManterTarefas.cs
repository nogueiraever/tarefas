using System;
using System.Collections.Generic;
using System.Linq;
using Tarefas.Dominio;
using Tarefas.Dominio.Repositorios;
using Tarefas.Infra.Dtos;

namespace Tarefas.Aplicacao.Controladores
{
    public class ManterTarefas : IManterTarefas
    {
        private readonly IRepositorioTarefa repositorioTarefa;
        private readonly IUnitOfWork unitOfWork;

        public ManterTarefas(IRepositorioTarefa repositorioTarefa,
                             IUnitOfWork unitOfWork)
        {
            this.repositorioTarefa = repositorioTarefa ?? throw new ArgumentNullException(nameof(repositorioTarefa));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void Atualizar(TarefaDto tarefaDto)
        {
            var tarefa = repositorioTarefa.ObterPorId(tarefaDto.Id);
            if (tarefa == null)
            {
                throw new NegocioException("Tarefa não encontrada.");
            }
            tarefa = MapearParaDominio(tarefaDto, tarefa);
            repositorioTarefa.Atualizar(tarefa);
            unitOfWork.SaveChanges();
        }

        public void Concluir(long id)
        {
            var tarefa = repositorioTarefa.ObterPorId(id);
            if (tarefa == null)
            {
                throw new NegocioException("Tarefa não encontrada.");
            }
            tarefa.Concluir();
            repositorioTarefa.Atualizar(tarefa);
            unitOfWork.SaveChanges();
        }

        public void Criar(TarefaDto tarefaDto)
        {
            var tarefa = MapearParaDominio(tarefaDto, new Tarefa());
            repositorioTarefa.Inserir(tarefa);
            unitOfWork.SaveChanges();
        }

        public IList<ListarTarefaDto> Listar()
        {
            return MapearParaDto(repositorioTarefa.ObterTodos());
        }

        public void Reativar(long id)
        {
            var tarefa = repositorioTarefa.ObterPorId(id);
            if (tarefa == null)
            {
                throw new NegocioException("Tarefa não encontrada.");
            }
            tarefa.Reativar();
            repositorioTarefa.Atualizar(tarefa);
            unitOfWork.SaveChanges();
        }

        public void Remover(long id)
        {
            var tarefa = repositorioTarefa.ObterPorId(id);
            if (tarefa == null)
            {
                throw new NegocioException("Tarefa não encontrada.");
            }
            tarefa.Remover();
            repositorioTarefa.Atualizar(tarefa);
            unitOfWork.SaveChanges();
        }

        private static ListarTarefaDto MapearParaDto(Tarefa tarefa)
        {
            return new ListarTarefaDto()
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Status = tarefa.Status
            };
        }

        private Tarefa MapearParaDominio(TarefaDto tarefaDto, Tarefa tarefa)
        {
            tarefa.Titulo = tarefaDto.Titulo;
            tarefa.Descricao = tarefaDto.Descricao;
            return tarefa;
        }

        private IList<ListarTarefaDto> MapearParaDto(IEnumerable<Tarefa> tarefas)
        {
            return tarefas?.Select(tarefa => MapearParaDto(tarefa)).ToList();
        }
    }
}