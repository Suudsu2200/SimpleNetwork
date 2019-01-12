using System;
using System.Threading.Tasks;
using SimpleNetwork.Server.Connections;

namespace SimpleNetwork.Server.ConnectionListeners
{
    public interface IConnectionListener
    {
        Task Listen();
        void Stop();
        event EventHandler<IConnection> OnNewConnection;
    }
}
