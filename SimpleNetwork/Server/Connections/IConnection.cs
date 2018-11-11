using System.Net.Security;

namespace SimpleNetwork.Server.Connections
{
    public interface IConnection
    {
        AuthenticatedStream UnderlyingStream { get; }
    }
}
