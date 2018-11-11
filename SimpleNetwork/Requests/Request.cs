using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.Requests
{
    public class Request : IRequest
    {
        public Type RequestType { get; set; }
        public object Body { get; set; }
    }
}
