using System.Net;

namespace DesafioSpedy.Exceptions.Base;

public abstract class DesafioSpedyException : Exception
{
    public DesafioSpedyException(string message) : base(message) { }
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}
