using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    internal class Barbare : Personnage
    {
        public Barbare(string pName) : base(pName)
        {
            Console.WriteLine("Je suis un nouveau Barbare !");
            DePv = "1D12";
        }
        public override void attack()
        {
            Console.WriteLine("Je suis un Barbare et j'attaque !");
        }
    }
}
