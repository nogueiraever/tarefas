using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Net;

namespace Tarefas.Api
{
    public class ResultadoBase : ObjectResult
    {
        public ResultadoBase(ModelStateDictionary modelState)
            : base(RetornaBaseModel(modelState))
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
        }

        public ResultadoBase(string mensagem)
            : base(RetornaBaseModel(mensagem))
        {
            StatusCode = 601;
        }

        public ResultadoBase(string mensagem, int statusCode)
            : base(RetornaBaseModel(mensagem))
        {
            StatusCode = statusCode;
        }

        public static RetornoBase RetornaBaseModel(ModelStateDictionary modelState)
        {
            var dto = new RetornoBase
            {
                Mensagens = modelState.Keys
                   .SelectMany(key => modelState[key].Errors.Select(x => new string(x.ErrorMessage)))
                   .ToList()
            };
            return dto;
        }

        public static RetornoBase RetornaBaseModel(string mensagem)
        {
            return new RetornoBase(mensagem);
        }
    }
}