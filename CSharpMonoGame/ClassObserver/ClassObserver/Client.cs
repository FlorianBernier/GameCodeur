using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Client : implemante l'interface ISubscriber
namespace ClassObserver
{
    public class Client : ISubscriber
    {
        public string Name { get; private set; }


        public Client(string name)
        {
            Name = name;
        }

        public void OnNotify(IPublisher magasin)
        {
            Debug.WriteLine($"Client : {Name} Le magasin a recu du stock.");
        }
    }
}
