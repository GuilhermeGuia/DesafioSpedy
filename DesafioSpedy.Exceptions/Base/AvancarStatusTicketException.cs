using System.Net;

namespace DesafioSpedy.Exceptions.Base;

public class AvancarStatusTicketException : DesafioSpedyException
{
    private readonly IList<string> _errorMessages;
    public AvancarStatusTicketException(string errorMessage) : base(errorMessage)
    {
        _errorMessages = [errorMessage];
    }

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    public override IList<string> GetErrorMessages() => _errorMessages;
}
