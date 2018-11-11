using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace SimpleNetwork.Client
{


    public class SimpleClient
    {
        private SslStream _stream;
        private TcpClient _client;

        public SimpleClient()
        {
            _client = new TcpClient();
            _client.Connect("127.0.0.1", 443);
            _stream = new SslStream(_client.GetStream());
            _stream.AuthenticateAsClient("test.simplenetwork.com");
        }

        public void Request(object request)
        {
            new JsonSerializer().Serialize(new JsonTextWriter(new StringWriter(new StringBuilder())), request);
        }

    }
}
