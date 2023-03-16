using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    internal class Personnage
    {
        public string Name { get; set; }
        public int TotalPv { get; set; }
        public string DePv { get; protected set; }

        public Personnage(string pName)
        {
            Console.WriteLine("Je suis un nouveau Personnage, mon nom est "+ pName);
            DePv = "";
            Name = pName;
            TotalPv = 0;
            Console.WriteLine(TotalPv);
        }

    }
}
