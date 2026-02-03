using System.Net;

namespace DesafioSpedy.Exceptions.Base;

public class CreateTicketException : DesafioSpedyException
{
    private readonly IList<string> _errorMessages;
    public CreateTicketException(string errorMessage) : base(errorMessage)
    {
        _errorMessages = [errorMessage];
    }
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    public override IList<string> GetErrorMessages() => _errorMessages;
}
