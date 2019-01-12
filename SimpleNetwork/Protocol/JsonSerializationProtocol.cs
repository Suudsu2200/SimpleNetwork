using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleNetwork.Requests;

namespace SimpleNetwork.Protocol
{
    public class JsonSerializationProcotol : ISerializationProtocol
    {
        public void Serialize<T>(Stream stream, T serializationTarget)
        {
            JsonSerializer serializer = new JsonSerializer();
            StreamWriter writer = new StreamWriter(stream);
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter,
                    JObject.FromObject(
                        new
                        {
                            Route = ((Route) Attribute.GetCustomAttribute(typeof(T), typeof(Route))).RoutePath,
                            Body = serializationTarget
                        })
                );
            }
        }

        public object Deserialize(Stream stream, Type requestType)
        {
            Task<string> readTask = null;
            StreamReader reader = new StreamReader(stream);

            while (readTask?.Result == null)
            {
                readTask = reader.ReadLineAsync();
                readTask.Wait();
            }
            JObject json = JObject.Parse(readTask.Result);
            return json["Body"].ToObject(requestType);
        }
    }
}
