using ClassState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// class etats walk 
namespace State
{
    public class Walk : IZombieState
    {
        private Zombie _zombie;
        public Walk(Zombie newZombie)
        {
            _zombie = newZombie;
        }
        public void DoSomething()
        {
            Debug.WriteLine("Le zombie rode");

            if (_zombie.WhatHappen == ZombieStimuli.SeeHuman)
            {
                _zombie.ChangeState(new Chase(_zombie));
            }
        }
    }
}
