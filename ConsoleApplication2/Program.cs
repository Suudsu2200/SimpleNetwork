using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SimpleNetwork;
using SimpleNetwork.Server;
using SimpleNetwork.Server.ConnectionListeners;

namespace ConsoleApplication2
{
    public class Program
    {
        static void Main(string[] args)
        {
            X509Certificate2Collection certCollection = new X509Certificate2Collection();
            certCollection.Import("C:\\src\\personal\\SimpleNetwork\\certs\\simplenetwork.test.com.pfx", "GoyangiX3", X509KeyStorageFlags.PersistKeySet);
            SimpleServer server = new SimpleServer(new SslConnectionListener(IPAddress.Parse("127.0.0.1"), 443, certCollection[0]));
            server.Start();
        }
    }
}
