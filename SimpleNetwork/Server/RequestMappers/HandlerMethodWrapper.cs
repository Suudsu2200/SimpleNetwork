using System.Reflection;
using SimpleNetwork.Server.RequestHandlers;

namespace SimpleNetwork.Server.RequestMappers
{
    public class HandlerMethodWrapper
    {
        public IRequestHandler Actor { get; set; }
        public MethodInfo Method { get; set; }

        public void Invoke()
        {
            Method.Invoke(Actor, new object[] { });
        }
    }
}
