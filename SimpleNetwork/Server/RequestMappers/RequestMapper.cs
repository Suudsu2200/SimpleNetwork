using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleNetwork.Requests;
using SimpleNetwork.Server.RequestHandlers;

namespace SimpleNetwork.Server.RequestMappers
{
    public class RequestMapper : IRequestMapper
    {
        private readonly Dictionary<Type, HandlerMethodWrapper> _requestTypeToHandlerMap;

        public RequestMapper()
        {
            _requestTypeToHandlerMap = new Dictionary<Type, HandlerMethodWrapper>();
            foreach (Assembly assembly in new Assembly[] {Assembly.GetEntryAssembly()})
            {
                foreach (
                    Type type in
                    assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IRequestHandler))))
                {
                    IRequestHandler handler = (IRequestHandler) Activator.CreateInstance(type);
                    foreach (MethodInfo methodInfo in type.GetMethods().Where(method => method.Name == "Handle"))
                    {
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        if (parameters.Length != 1)
                            continue;
                        _requestTypeToHandlerMap.Add(parameters[0].ParameterType,
                            new HandlerMethodWrapper
                            {
                                Actor = handler,
                                Method = methodInfo
                            });
                    }
                }
            }
        }

        public HandlerMethodWrapper MapRequest(IRequest request)
        {
            return _requestTypeToHandlerMap[request.RequestType];
        }
    }
}
