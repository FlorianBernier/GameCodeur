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
            Personnage monPerso = new Barbare("Conan");
            Console.WriteLine("Le nom du personnage est "+ monPerso.Name);
            Console.ReadKey();
        }
    }
}
