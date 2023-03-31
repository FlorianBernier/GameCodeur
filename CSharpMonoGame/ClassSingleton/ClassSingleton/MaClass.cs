using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Créé une instance unique (permet d'acceder a des fonction unique)
namespace ClassSingleton
{
    public class MaClass
    {
        public string Value { get; set; }
        private static MaClass instance;

        private MaClass() 
        {
        
        }

        public static MaClass GetInstance()
        {
            if (instance == null)
            {
                instance = new MaClass();
            }
            return instance;
        }
    }
}
