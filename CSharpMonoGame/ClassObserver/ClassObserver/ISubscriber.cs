using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ISDubscriber : oblige les class qui l'implemante a utiliser la méthode
namespace ClassObserver
{
    public interface ISubscriber
    {
        // Quand il est notifié
        void OnNotify(IPublisher publisher);
    }
}
