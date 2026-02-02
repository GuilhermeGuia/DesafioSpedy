using System.Net;

namespace DesafioSpedy.Exceptions.Base;

public class CredenciaisInvalidasException : DesafioSpedyException
{
    private readonly IList<string> _errorMessages;

    public CredenciaisInvalidasException(string errorMessage) : base(errorMessage)
    {
        _errorMessages = [errorMessage];
    }

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    public override IList<string> GetErrorMessages() => _errorMessages;
}
