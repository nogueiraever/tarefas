using Microsoft.AspNetCore.Mvc.Filters;

namespace Tarefas.Api.Infra
{
    public class ValidarDtoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ResultadoBase(context.ModelState);
            }
        }
    }
}