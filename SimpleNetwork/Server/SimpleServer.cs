using System.Collections.Generic;
using System.Threading;
using SimpleNetwork.Requests;
using SimpleNetwork.Server.ConnectionListeners;
using SimpleNetwork.Server.Connections;
using SimpleNetwork.Server.RequestMappers;
using Simple = SimpleNetwork.StreamReaders;

namespace SimpleNetwork.Server
{
    public class SimpleServer
    {
        private IConnectionListener _connectionListener { get; set; }
        private IDictionary<int, IConnection> _activeConnections { get; set; }   
        private IRequestMapper _requestMapper { get; set; }
        private Simple.StreamReader _streamReader { get; set; }
        private int _nextConnectionId = 0;

        public SimpleServer(IConnectionListener connectionListener)
        {
            _connectionListener = connectionListener;
            _activeConnections = new Dictionary<int, IConnection>();
            _requestMapper = new RequestMapper();
            _streamReader = new Simple.JsonStreamReader();
        }

        public void Start()
        {
            _connectionListener.OnNewConnection +=
                (sender, details) => { _activeConnections[_nextConnectionId] = details; };
            _connectionListener.Listen();

            while (true)
            {
                foreach (IConnection connection in _activeConnections.Values)
                {
                    IRequest request = null;
                    if ((request = _streamReader.Read(connection.UnderlyingStream)) != null)
                    {
                        ThreadPool.QueueUserWorkItem(o => _requestMapper.MapRequest(request).Invoke(), request.Body);
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
