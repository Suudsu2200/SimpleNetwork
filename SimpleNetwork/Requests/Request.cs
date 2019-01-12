using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.Requests
{
    public class Request
    {
        public object Body { get; private set; }
        public Request(object body)
        {
            Body = body;
        }
    }
}
