using System.Net.Security;

namespace SimpleNetwork.Server.Connections
{
    public class Connection : IConnection
    {
        public AuthenticatedStream UnderlyingStream { get; set; }
    }
}
