using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    internal class Druide : Personnage
    {
        public void CastSpell(string pNameSpell)
        {
            Console.WriteLine("Je lance un sort " + pNameSpell);
        }
        public Druide(string pName) : base(pName)
        {
            Console.WriteLine("Je suis un nouveau Druide !");
            DePDV = "1D8";
        }
    }
}