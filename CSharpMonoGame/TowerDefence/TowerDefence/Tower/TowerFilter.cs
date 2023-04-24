using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class TowerFilter
    {
        public static int towerSelected = 0;
        private List<ITower> towers;

        public TowerFilter() 
        {
            towers = new List<ITower>();
        }

        public TowerFilter addTower()
        {
            towers.Add( new TowerIce());
            return this;
        }

        public TowerFilter removeTower(ITower t)
        {
            
            towers.Remove(t);
            return this;
        }






    }
}
