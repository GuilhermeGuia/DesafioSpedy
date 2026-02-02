using DesafioSpedy.Api.Response;
using DesafioSpedy.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioSpedy.Api.Filters;

public class ExceptionGlobalFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DesafioSpedyException castDesafioSpedyException)
            HandleProjectException(castDesafioSpedyException, context);
        else
            HandleUnknowException(context);
    }

    private void HandleProjectException(DesafioSpedyException castDesafioSpedyException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)castDesafioSpedyException.GetStatusCode();
        context.Result = new ObjectResult(new BaseRequest<string>(castDesafioSpedyException.GetErrorMessages()));
    }

    private void HandleUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new BaseRequest<string>(["Erro interno"]));
    }
}