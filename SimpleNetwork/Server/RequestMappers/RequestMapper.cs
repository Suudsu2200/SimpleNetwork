using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using SimpleNetwork.Requests;
using SimpleNetwork.Server.RequestHandlers;

namespace SimpleNetwork.Server.RequestMappers
{
    public class RequestMapper : IRequestMapper
    {
        private readonly Dictionary<string, HandlerMethodWrapper> _requestTypeToHandlerMap;

        public RequestMapper()
        {
            _requestTypeToHandlerMap = new Dictionary<string, HandlerMethodWrapper>();
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
                        _requestTypeToHandlerMap.Add( ((Route) parameters[0].GetCustomAttributes(typeof(Route), true)[0]).RoutePath,
                            new HandlerMethodWrapper
                            {
                                Actor = handler,
                                Method = methodInfo
                            });
                    }
                }
            }
        }

        public HandlerMethodWrapper MapRequest(object request)
        {
            Console.WriteLine("Mapping...");
            return null; // _requestTypeToHandlerMap[request.Route.RoutePath];
        }
    }
}
