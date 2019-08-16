using System.Collections.Generic;

namespace Tarefas.Api
{
    public class RetornoBase
    {
        public RetornoBase(string mensagem)
        {
            Mensagens = new List<string>
            {
                mensagem
            };
        }

        public RetornoBase()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}