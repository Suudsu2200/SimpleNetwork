using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNetwork.Requests;

namespace SimpleNetwork.StreamReaders
{
    public abstract class StreamReader
    {
        public abstract IRequest Read(Stream stream);
    }
}
