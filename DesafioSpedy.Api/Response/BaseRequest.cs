namespace DesafioSpedy.Api.Response;

public class BaseRequest<T>
{
    public T? Result { get; set; }
    public bool Success { get; set; }
    public IList<string>? Errors { get; set; }
    public BaseRequest(T result)
    {
        Success = true;
        Result = result;
    }
    public BaseRequest(IList<string> errors)
    {
        Errors = errors;
        Success = false;
    }
}