using ClassState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// class etats attack
namespace State
{
    public class Attack : IZombieState
    {
        private Zombie _zombie;

        public Attack(Zombie newZombie) 
        {
            _zombie = newZombie;
        }



        public void DoSomething()
        {
            Debug.WriteLine("Le zombie attaque l'humain");

            switch (_zombie.WhatHappen) 
            {
                case ZombieStimuli.OnHuman:
                    Debug.WriteLine("Le zombie est toujours au contact de l'humain");
                    break;

                case ZombieStimuli.SeeNothing:
                    Debug.WriteLine("Le zombie ne voit plus l'humain");
                    _zombie.ChangeState(new Walk(_zombie));
                    break;
                case ZombieStimuli.SeeHuman:
                    Debug.WriteLine("Le zombie voit l'humain");
                    _zombie.ChangeState(new Chase(_zombie));
                    break;

                default:
                    break;
            }
        }
    }
}
