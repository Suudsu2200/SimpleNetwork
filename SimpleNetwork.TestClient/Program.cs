using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNetwork.Client;

namespace SimpleNetwork.TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new SimpleClient().Request(12);
        }
    }
}
