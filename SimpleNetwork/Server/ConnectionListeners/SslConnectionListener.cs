using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using SimpleNetwork.Server.Connections;

namespace SimpleNetwork.Server.ConnectionListeners
{
    public class SslConnectionListener : BaseConnectionListener
    {
        private readonly X509Certificate _serverCertificate;

        public SslConnectionListener(X509Certificate serverCertificate, IPAddress listeningIpAddress = null, int listeningPort = 0)
            : base(listeningIpAddress, listeningPort)
        {
            _serverCertificate = serverCertificate;
        }

        protected override Stream InitializeStream()
        {
            TcpClient client = _tcpListener.AcceptTcpClient();
            SslStream sslStream = new SslStream(client.GetStream());
            sslStream.AuthenticateAsServer(_serverCertificate);
            return sslStream;
        }
    }
}
