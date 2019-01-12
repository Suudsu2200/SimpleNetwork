using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.Requests
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class Route : Attribute
    {
        public string RoutePath { get; private set; }

        public Route(string routePath)
        {
            RoutePath = routePath;
        }
    }
}
