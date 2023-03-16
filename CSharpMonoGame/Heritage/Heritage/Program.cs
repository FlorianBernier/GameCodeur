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
            Console.WriteLine("Le nom du personnage est "+ monBarbare.Name);
            monBarbare.attack();

            Console.WriteLine("=====================================");

            Druide monDruide = new Druide("Soa");
            Console.WriteLine("Le nom du personnage est " + monDruide.Name);
            monDruide.CastSpell("Heal");
            monDruide.attack();


            Console.WriteLine("=====================================");

            Console.ReadKey();
        }
    }
}
