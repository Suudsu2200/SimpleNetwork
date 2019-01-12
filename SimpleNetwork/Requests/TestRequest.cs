using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.Requests
{
    [Route("abcd")]
    public class TestRequest
    {
        public string Testparam = "param";
    }
}
