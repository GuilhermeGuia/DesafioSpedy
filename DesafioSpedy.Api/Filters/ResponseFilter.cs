using DesafioSpedy.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioSpedy.Api.Filters;

public class ResponseFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is not ObjectResult objectResult)
        {
            context.Result = new ObjectResult(new BaseRequest<string>(string.Empty));
            return;
        }

        var value = objectResult.Value;

        if (value is null)
        {
            context.Result = new ObjectResult(new BaseRequest<string>(string.Empty));
            return;
        }

        var responseType = typeof(BaseRequest<>).MakeGenericType(value.GetType());
        var responseInstance = Activator.CreateInstance(responseType, value);
        context.Result = new ObjectResult(responseInstance);
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }
}
