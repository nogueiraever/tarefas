namespace Tarefas.Infra.Dtos
{
    public class TarefaDto
    {
        public string Descricao { get; set; }
        public long Id { get; set; }

        [Obrigatorio]
        public string Titulo { get; set; }
    }
}