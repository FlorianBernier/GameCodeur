using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barbare monBarbare = new Barbare("Conan");
            Druide monDruide = new Druide("Soa");

            List<Personnage> maListe = new List<Personnage>();
            maListe.Add(monBarbare);
            maListe.Add(monDruide);
            foreach (Personnage item in maListe)
            {
                item.attack();
            }

            Console.ReadKey();
        }
    }
}
