using System;

namespace Tarefas.Dominio
{
    public class Entidade
    {
        public Entidade()
        {
            DataCadastro = DateTime.Now;
        }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        public long Id { get; set; }
    }
}