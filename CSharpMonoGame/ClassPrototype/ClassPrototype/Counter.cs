using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPrototype
{
    public class Counter : ICloneable
    {
        public int I { get; private set; }
        private int _iMax;


        public Counter(int iMax)
        {
            _iMax = iMax;
        }

        private Counter(Counter counter)
        {
            I = counter.I;
            _iMax = counter._iMax; 
        }



        public void Count()
        {
            while (I < _iMax) 
            {
                Debug.WriteLine($"I = {I} ");
                I++;
            }
        }

        public object Clone()
        {
            return new Counter(this);
        }
    }
}
