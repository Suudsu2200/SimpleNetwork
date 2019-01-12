using System.IO;
using System.Net.Security;

namespace SimpleNetwork.Server.Connections
{
    public class Connection : IConnection
    {
        public Stream UnderlyingStream { get; set; }
    }
}
