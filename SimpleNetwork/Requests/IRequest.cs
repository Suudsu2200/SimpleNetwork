using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.Requests
{
    public interface IRequest
    {
        Type RequestType { get; set; }
        object Body { get; set; }
    }
}
