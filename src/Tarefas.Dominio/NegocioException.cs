using System;

namespace Tarefas.Dominio
{
    public class NegocioException : Exception
    {
        public NegocioException(string mensagem) : base(mensagem)
        {
        }
    }
}