using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using SimpleNetwork.Protocol;
using SimpleNetwork.Requests;

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
            //  _stream.Write(new JsonSerializer().Serialize(new JsonTextWriter(new StringWriter(new StringBuilder())), "hello!"));
            /*JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, "hello!");
            }*/
            new JsonSerializationProcotol().Serialize(_stream, new TestRequest());
        }

    }
}
