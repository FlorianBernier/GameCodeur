using Microsoft.Xna.Framework;
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




    public abstract class Tower
    {
        public string name;
        public int qte;
        public bool cdTir;
        public bool startCd;

        public Tower()
        {
            //tout ce qui est en commun: variables
        }
        //toutes les methodes en commun ou qui DOIVENT etre implémentées
        public abstract void attack(); //indique que tous les enfants auront une méthode attaque qu'elles devront définir elle memes
        
        public virtual void Update(GameTime gameTime)
        {
            Debug.WriteLine("1 seconde!");
            //tous les enfants auront un update, qui pourront etre override si elles le souhaitent
        }
        public virtual void Draw(GameTime gameTime)
        {
            Debug.WriteLine("1 dessin!");
            //tous les enfants auront un update, qui pourront etre override si elles le souhaitent
        }
    }
    public class Tower1: Tower
    {
        private Tower tower;
        public Tower1(Tower tower): base()
        {
            this.tower = tower;
        }
        public override void attack()
        {
            Debug.WriteLine("BAM!");
        }
        public override void Update(GameTime gameTime) //override indique que la fille peut effacer ou non les parametres de la mere
        {
            Debug.WriteLine("UPDATE!");
            attack();
            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        public void AttaqueSpeciale()
        {
            
        }
    }
    public class Tower2 : Tower
    {
        private Tower tower;
        public Tower2(Tower tower) : base()
        {
            this.tower = tower;
        }
        public override void attack()
        {
            Debug.WriteLine("BOOM!");
        }
        public override void Update(GameTime gameTime) //override indique que la fille peut effacer ou non les parametres de la mere
        {
            Debug.WriteLine("UPDATE!");
            attack();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Debug.WriteLine("DESSIN!");
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
