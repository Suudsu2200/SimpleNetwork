using System.IO;
using Newtonsoft.Json;
using SimpleNetwork.Requests;

namespace SimpleNetwork.StreamReaders
{ 

   /* public class JsonStreamReader : StreamReader
    {
        /*private readonly JsonSerializer _serializer;
        public JsonStreamReader()
        {
            _serializer = new JsonSerializer();
        }

        public override Request Read(Stream stream)
        {
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
            using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
            {
                return new Request() {Body = _serializer.Deserialize(jsonTextReader)};
            }
        }
    }*/
}
