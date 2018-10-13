using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using SimpleNetwork.ConnectionListeners;

namespace SimpleNetwork
{
    public interface IRequestListener
    {
        void Listen();
        void Stop();
        IDictionary<int, IConnectionDetails> ActiveConnections { get; set; }
        event EventHandler<IRequest> OnNewRequest;
    }

    public interface IRequest
    {
    }

    public interface IRequestHandler<T>
    {
        void Handler(T request);
    }

    public interface IConnectionDetails { AuthenticatedStream UnderlyingStream { get; } }
    public class ConnectionDetails : IConnectionDetails { public AuthenticatedStream UnderlyingStream { get; set; } }

    public class SimpleServer
    {
        public IConnectionListener ConnectionListener { protected get; set; }
        public IRequestListener RequestListener { protected get; set; }
        
        private IDictionary<Type, IRequestHandler<object>> RequestMap { get; set; }
        private int NextConnectionId = 0;

        public SimpleServer()
        {
            
        }

        public void Start()
        {
            ConnectionListener.OnNewConnection +=
                (sender, details) => { RequestListener.ActiveConnections[NextConnectionId] = details; };
            RequestListener.OnNewRequest +=
                (sender, details) =>
                {
                    
                };

            ConnectionListener.Listen();
            RequestListener.Listen();
        }

    }
}
