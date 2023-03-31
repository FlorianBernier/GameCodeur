using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObserver
{
    public class Client : ISubscriber
    {
        public void OnNotify(IPublisher magasin)
        {
            Debug.WriteLine("Client : Le magasin a recu du stock.");
        }
    }
}
