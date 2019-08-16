using System;
using Xunit;

namespace Tarefas.Dominio.Teste
{
    public class TarefaTeste
    {
        [Fact(DisplayName = "Deve Concluir Tarefa")]
        public void DeveConcluirTarefa()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Nova tarefa",
                Descricao = "Nova tarefa"
            };

            Assert.True(tarefa.Status == StatusTarefa.Novo);
            tarefa.Concluir();
            Assert.True(tarefa.Status == StatusTarefa.Concluido);
            Assert.True(tarefa.DataConclusao.Value.Date == DateTime.Now.Date);
        }

        [Fact(DisplayName = "Deve Criar Tarefa com status Novo")]
        public void DeveCriarTarefaComStatusNovo()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Título tarefa",
                Descricao = "Descrição tarefa"
            };
            Assert.Equal("Título tarefa", tarefa.Titulo);
            Assert.Equal("Descrição tarefa", tarefa.Descricao);
            Assert.True(tarefa.Status == StatusTarefa.Novo);
            Assert.False(tarefa.DataConclusao.HasValue);
            Assert.False(tarefa.DataRemocao.HasValue);
            Assert.False(tarefa.DataUltimaAlteracao.HasValue);
        }

        [Fact(DisplayName = "Deve Reativar Tarefa")]
        public void DeveReativarTarefa()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Nova tarefa",
                Descricao = "Nova tarefa"
            };

            Assert.True(tarefa.Status == StatusTarefa.Novo);
            tarefa.Concluir();
            Assert.True(tarefa.Status == StatusTarefa.Concluido);
            tarefa.Reativar();
            Assert.True(tarefa.Status == StatusTarefa.Novo);
            Assert.False(tarefa.DataConclusao.HasValue);
        }

        [Fact(DisplayName = "Deve Remover Tarefa")]
        public void DeveRemoverTarefa()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Nova tarefa",
                Descricao = "Nova tarefa"
            };

            Assert.True(tarefa.Status == StatusTarefa.Novo);
            tarefa.Remover();
            Assert.True(tarefa.Status == StatusTarefa.Removido);
            Assert.True(tarefa.DataRemocao.Value.Date == DateTime.Now.Date);
        }

        [Fact(DisplayName = "Não Deve Permitir Concluir Tarefa")]
        public void NaoDevePermitirConcluirTarefa()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Nova tarefa",
                Descricao = "Nova tarefa"
            };

            Assert.True(tarefa.Status == StatusTarefa.Novo);
            tarefa.Remover();
            Assert.Throws<NegocioException>(() => tarefa.Concluir());
            Assert.True(tarefa.Status == StatusTarefa.Removido);
            Assert.False(tarefa.DataConclusao.HasValue);
        }

        [Fact(DisplayName = "Não Deve Permitir Reativar Tarefa")]
        public void NaoDevePermitirReativarTarefa()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Nova tarefa",
                Descricao = "Nova tarefa"
            };

            Assert.True(tarefa.Status == StatusTarefa.Novo);
            tarefa.Remover();
            Assert.Throws<NegocioException>(() => tarefa.Reativar());
            Assert.True(tarefa.Status == StatusTarefa.Removido);
            Assert.False(tarefa.DataConclusao.HasValue);
        }

        [Fact(DisplayName = "Não Deve Permitir Remover Tarefa")]
        public void NaoDevePermitirRemoverTarefa()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "Nova tarefa",
                Descricao = "Nova tarefa"
            };

            Assert.True(tarefa.Status == StatusTarefa.Novo);
            tarefa.Concluir();
            Assert.Throws<NegocioException>(() => tarefa.Remover());
            Assert.True(tarefa.Status == StatusTarefa.Concluido);
            Assert.False(tarefa.DataRemocao.HasValue);
        }
    }
}