using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    internal class Personnage
    {
        public string Name;
        public int TotalPDV;
        protected string DePDV;

        public Personnage(string pName)
        {
            Console.WriteLine("Je suis un nouveau Personnage, mon nom est "+ pName);
            DePDV = "";
            Name = pName;
        }

    }
}
