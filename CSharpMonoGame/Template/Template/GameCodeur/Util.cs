﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCodeur
{
    class Util
    {
        static Random RandomGenerator = new Random();

        public static void SetRandomSeed(int seed)
        {
            RandomGenerator = new Random(seed);
        }

        public static int GetInt(int pMin,  int pMax)
        {
            return RandomGenerator.Next(pMin, pMax + 1);
        }

        public static bool collideByBox(IActor p1, IActor p2)
        {
            return p1.BoudingBox.Intersects(p2.BoudingBox);
        }
    }
}
