using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleNetwork.Server.Connections;

namespace SimpleNetwork.Server.ConnectionListeners
{
    public abstract class BaseConnectionListener : IConnectionListener
    {
        private bool _isListening;

        protected TcpListener _tcpListener;
        protected readonly int _listeningPort = 0;
        protected readonly IPAddress _listeningIpAddress = IPAddress.Any;

        public event EventHandler<IConnection> OnNewConnection;

        protected abstract Stream InitializeStream();

        protected BaseConnectionListener(IPAddress listeningIpAddress, int listeningPort)
        {
            _listeningPort = listeningPort;
            _listeningIpAddress = listeningIpAddress;
        }

        public Task Listen()
        {
            _tcpListener = new TcpListener(_listeningIpAddress, _listeningPort);
            _tcpListener.Start();
            _isListening = true;

            return Task.Run(() =>
            {
                while (_isListening)
                {
                    if (!_tcpListener.Pending())
                    {
                        OnNewConnection(this, new Connection {UnderlyingStream = InitializeStream()});
                    }
                }
            });
        }

        public void Stop()
        {
            _isListening = false;
            _tcpListener.Stop();
        }
    }
}
