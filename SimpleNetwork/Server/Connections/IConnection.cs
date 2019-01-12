using System.IO;
using System.Net.Security;

namespace SimpleNetwork.Server.Connections
{
    public interface IConnection
    {
        Stream UnderlyingStream { get; }

    }
}
