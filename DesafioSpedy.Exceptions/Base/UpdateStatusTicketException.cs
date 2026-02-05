using System.Net;

namespace DesafioSpedy.Exceptions.Base;

public class UpdateStatusTicketException : DesafioSpedyException
{
    private readonly IList<string> _errorMessages;
    public UpdateStatusTicketException(string errorMessage) : base(errorMessage)
    {
        _errorMessages = [errorMessage];
    }

    public UpdateStatusTicketException(List<string> errorMessages) : base("Erro cadastro de ticket")
    {
        _errorMessages = errorMessages;
    }

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    public override IList<string> GetErrorMessages() => _errorMessages;
}
