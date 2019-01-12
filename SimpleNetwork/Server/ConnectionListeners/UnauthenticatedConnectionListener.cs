using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.Server.ConnectionListeners
{
    public class UnauthenticatedConnectionListener : BaseConnectionListener
    {
        public UnauthenticatedConnectionListener(IPAddress listeningIpAddress = null, int listeningPort = 0)
            : base(listeningIpAddress, listeningPort)
        {
            
        }

        protected override Stream InitializeStream()
        {
            return _tcpListener.AcceptTcpClient().GetStream();
        }
    }
}
