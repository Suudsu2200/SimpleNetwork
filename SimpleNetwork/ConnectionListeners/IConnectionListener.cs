using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.ConnectionListeners
{
    public interface IConnectionListener
    {
        void Listen();
        void Stop();
        event EventHandler<IConnectionDetails> OnNewConnection;
    }
}
