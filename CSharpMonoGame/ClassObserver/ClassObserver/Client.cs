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




    public class Tower
    {
        public string name;
        public int qte;
        public bool cdTir;
        public bool startCd;

        public void attack()
        {

        }
    }



    public class TowerFilter
    {
        List<Tower> liste;
        public TowerFilter(List<Tower> liste)
        {
            this.liste = liste;


        }

        public TowerFilter NameContain(string name)
        {

            liste = liste.FindAll(tower => tower.name.Contains(name));
            return this;
        }
        public TowerFilter QteGt(int qte)
        {
            liste = liste.FindAll(tower => tower.qte > qte);
            return this;
        }

        public TowerFilter QteLt(int qte)
        {
            liste = liste.FindAll(tower => tower.qte < qte);
            return this;
        }

        public TowerFilter CooldownShootIsUp()
        {
            liste = liste.FindAll(tower => tower.cdTir);
            return this;
        }
        public TowerFilter Attack()
        {
            liste.ForEach(tower => tower.attack());
            return this;
        }

        public TowerFilter RestartCooldown()
        {
            liste.ForEach(tower => tower.startCd = true);
            return this;
        }



        public List<Tower> Build()
        {
            return liste;
        }



        public void main()
        {
            List<Tower> liste = new List<Tower>
            {
                new Tower(),
                new Tower(),
                new Tower(),
                new Tower(),
                new Tower(),
            };

            new TowerFilter(liste)
                .all()
                    .CooldownShootIsUp()
                        .Attack()
                        .RestartCooldown()
                .all()
                    .hasBeenDestroyed()
                        .Delete()
                .all()
                    .AddAtk(5)
                .all()
                    .type(Type.FIRE)
                        .IsParalized()
                .all()

        }

    }
}
