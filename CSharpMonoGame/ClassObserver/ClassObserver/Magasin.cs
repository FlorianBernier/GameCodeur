using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Magasin : implemante l'interface IPublisher  
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
            Debug.WriteLine("Magasin : Inscription du nouveau client.");
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
            float rand = new Random().Next(2);
            Stock = true;
            if (rand == 0)
            {
                Stock = false;
            }



            Debug.WriteLine($"Magasin : Etats des stocks : {Stock} ");

            if (Stock)
            {
                Notify();
            }
        }
    }
    

    public interface ITower
    {
        event Upgrade upgradeDelegue;

        public void attack();

        public delegate void Upgrade();
    }



    public class FireTower : ITower
    {


        public FireTower(String type)
        {
            switch (type)
            {
                case "arme 1":
                    upgradeDelegue = towerFeu1;
                    break;
                case "arme 2":
                    upgradeDelegue = towerFeu2;
                    break;
                case "arme 3":
                    upgradeDelegue = towerFeu3;
                    break;
            }
        }

        public event ITower.Upgrade upgradeDelegue;

        public void attack()
        {
        }

        public void towerFeu1()
        {
        }

        public void towerFeu2()
        {
        }
        public void towerFeu3()
        {
        }


    }


    public class IceTower : ITower
    {
        public event ITower.Upgrade upgradeDelegue;

        public void attack()
        {
            throw new NotImplementedException();
        }
    }


    public class A
    {
        public void ezaeza()
        {
            List<ITower> list = new List<ITower>{
                new IceTower(),
                new FireTower("arme 2"),
            };


            list.ForEach(tower => tower.attack());

            list.ForEach(tower => tower.Equals(null));

        }
    }

}




/*
public class PlayerBuilder
{

    private string name;
    private string description;
    private Vector2 pos;
    private int level;
    private long life;
    private List<string> names;


    public PlayerBuilder()
    {
        List<string> names = new List<string>();
    }

    public PlayerBuilder addName(string name)
    {
        names.Add(name);
        return this;
    }

    public PlayerBuilder Name(string name)
    {
        this.name = name;
        return this;
    }
    public PlayerBuilder Description(string description)
    {
        this.description = description;
        return this;
    }
    public PlayerBuilder Pos(Vector2 pos)
    {
        this.pos = pos;
        return this;
    }
    public PlayerBuilder Level(int level)
    {
        this.level = level;
        return this;
    }

    public PlayerBuilder Life(int life)
    {
        this.life = life;
        return this;
    }

    public Player Build()
    {
        return new Player(this.name, this.description, this.pos, this.level, this.life);
    }

    public class Player
    {
        private string name;
        private string description;
        private Vector2 pos;
        private int level;
        private long life;
        private List<string> names;

        public Player(string name, string description, Vector2 pos, int level, long life)
        {
            this.name = name;
            this.description = description;
            this.pos = pos;
            this.level = level;
            this.life = life;
        }
    }

    public void main()
    {
        Player monPlayer = (new PlayerBuilder())
            .Level(5)
            .addName("Flo")
            .addName("Allan")
            .addName("Aurore")
            .Description("Coucou new player")
            .Name("Soa")
            .Build();
    }
*/







}









