using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SimpleNetwork.Protocol;
using SimpleNetwork.Requests;
using SimpleNetwork.Server.ConnectionListeners;
using SimpleNetwork.Server.Connections;
using SimpleNetwork.Server.RequestMappers;


namespace SimpleNetwork.Server
{
    public class SimpleServer
    {
        private IConnectionListener _connectionListener { get; set; }
        private ISerializationProtocol _serializationProtocol { get; set; }
        private IRequestMapper _requestMapper { get; set; }

        private int _nextConnectionId = 0;

        public SimpleServer(IConnectionListener connectionListener, ISerializationProtocol serializationProtocol)
        {
            _connectionListener = connectionListener;
            _serializationProtocol = serializationProtocol;
            _requestMapper = new RequestMapper();
        }

        public void Start()
        {
            _connectionListener.OnNewConnection +=
                (source, connection) =>
                {
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            object request = _serializationProtocol.Deserialize(connection.UnderlyingStream, typeof(TestRequest));
                            Console.WriteLine(((TestRequest)request).Testparam);
                            //Console.WriteLine(request.ToString());
                           // _requestMapper.MapRequest((Request)request).Invoke();
                        }
                    });
                };
            Task.WaitAll(_connectionListener.Listen());
            

            /*while (true)
            {
                foreach (IConnection connection in _activeConnections.Values)
                {
                    string requestString = null;
                    using (StreamReader reader = new StreamReader(connection.UnderlyingStream))
                    {
                        Console.WriteLine("nut");
                        if ( ((SslStream)connection.UnderlyingStream). && (requestString = reader.ReadLine()) != null)
                        {
                            Console.WriteLine("hello!");
                            JObject parsedRequest = JObject.Parse(requestString);
                            Request requestObject = new Request (parsedRequest["Route"].ToObject<Route>(), parsedRequest["Body"]);
                            ThreadPool.QueueUserWorkItem(o => _requestMapper.MapRequest(requestObject).Invoke(), requestObject.Body);
                        }
                    }
                }
                Thread.Sleep(500);
            }*/
        }
    }
}
