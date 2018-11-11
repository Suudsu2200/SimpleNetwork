using System;
using SimpleNetwork.Server.Connections;

namespace SimpleNetwork.Server.ConnectionListeners
{
    public interface IConnectionListener
    {
        void Listen();
        void Stop();
        event EventHandler<IConnection> OnNewConnection;
    }
}
