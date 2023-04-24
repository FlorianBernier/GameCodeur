using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public abstract class Tower : ITower
    {


        public void Draw()
        {
        }


        public abstract void Attack();



    }
}
