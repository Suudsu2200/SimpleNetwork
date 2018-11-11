using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using SimpleNetwork.Server.Connections;

namespace SimpleNetwork.Server.ConnectionListeners
{
    public class SslConnectionListener : IConnectionListener
    {
        public event EventHandler<IConnection> OnNewConnection;

        private bool _isListening;
        private TcpListener _tcpListener;

        private readonly int _listeningPort;
        private readonly IPAddress _listeningIpAddress;
        private readonly X509Certificate _serverCertificate;

        public SslConnectionListener(IPAddress listeningIpAddress, int listeningPort, X509Certificate serverCertificate) 
        {
            _listeningIpAddress = listeningIpAddress;
            _listeningPort = listeningPort;
            _serverCertificate = serverCertificate;
        }

        public SslConnectionListener(X509Certificate serverCertificate)
        {
            _listeningIpAddress = IPAddress.Any;
            _listeningPort = 0;                     // Zero means service provider will provide port number
            _serverCertificate = serverCertificate;
        }

        public void Listen()
        {
            _tcpListener = new TcpListener(_listeningIpAddress, _listeningPort);
            _tcpListener.Start();
            _isListening = true;

            Task.Run(() =>
            {
                while (_isListening)
                {
                    if (!_tcpListener.Pending())
                    {
                        TcpClient client = _tcpListener.AcceptTcpClient();
                        SslStream sslStream = new SslStream(client.GetStream());
                        sslStream.AuthenticateAsServer(_serverCertificate);
                        OnNewConnection(null, new Connection {UnderlyingStream = sslStream});
                    }
                    Thread.Sleep(250);                    
                }
                _tcpListener.Stop();
            });
        }

        public void Stop()
        {
            _isListening = false;
        }

    }
}
