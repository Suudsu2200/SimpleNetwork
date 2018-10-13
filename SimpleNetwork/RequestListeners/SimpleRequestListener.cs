using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetwork.RequestListeners
{
    public class SimpleRequestListener : IRequestListener 
    {
        public IDictionary<int, IConnectionDetails> ActiveConnections { get; set; }
        public event EventHandler<IRequest> OnNewRequest;

        private bool _isListening;

        public void Listen()
        {
            Task.Run(() =>
            {
                while (_isListening)
                {
                    foreach (IConnectionDetails connection in ActiveConnections.Values)
                    {
                        
                    }
                }
            });
        }


        public void Stop()
        {
            
        }
    }
}
