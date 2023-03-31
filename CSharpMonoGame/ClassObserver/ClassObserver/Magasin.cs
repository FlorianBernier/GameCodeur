using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObserver
{
    public class Magasin : IPublisher
    {
        public bool Stock { get ; set; }
        private List<ISubscriber> _subscribers;


        public Magasin()
        {
            _subscribers = new List<ISubscriber>();
            Stock = false;
        }

        public void Register(ISubscriber subscriber) 
        {
            _subscribers.Add(subscriber);
            Debug.WriteLine("Magasin : Inscription d'un nouveau client.");
        }


        public void Unregister(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
            Debug.WriteLine("Magasin : Désinscription d'un client.");
        }

        public void Notify()
        {
            Debug.WriteLine("Magasin : Notification de tous les clients.");
            foreach (ISubscriber subscriber in _subscribers)
            {
                subscriber.OnNotify(this);
            }
        }


        public void DoSomething() 
        {
            Debug.WriteLine("Magasin : Chengement des stocks.");  
            int rand = new Random().Next(0, 2);
            Stock = true;
            if (rand == 0)
            {
                Stock = false;
            }

            Debug.WriteLine($"Magasin : Etats des stocks : {rand} ");

            if (Stock)
            {
                Debug.WriteLine("Magasin : Notification de tous les clients.");
                Notify();
            }
        }
    }
}
