using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// IPublisher : oblige les class qui l'implemante a utiliser les 3 méthode
namespace ClassObserver
{
    public interface IPublisher
    {
        // Inscrire un client 
        void Register(ISubscriber subscriber);

        
        // Désinscription d'un client
        void Unregister(ISubscriber subscriber);

        // Notifie tous les clients
        void Notify();
    }
}
