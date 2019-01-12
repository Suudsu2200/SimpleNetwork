using System;
using System.IO;
using System.Threading.Tasks;
using SimpleNetwork.Requests;

namespace SimpleNetwork.Protocol
{
    public interface ISerializationProtocol
    {
        void Serialize<T>(Stream stream, T serializationTarget);
        object Deserialize(Stream stream, Type requestType);
    }
}
