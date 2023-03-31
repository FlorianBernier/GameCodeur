using ClassState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// class etats chase
namespace State
{
    public class Chase : IZombieState
    {
        private Zombie _zombie;

        public Chase(Zombie newZombie)
        {
            _zombie = newZombie;
        }



        public void DoSomething()
        {
            Debug.WriteLine("Le zombie pourchasse un humain");

            switch (_zombie.WhatHappen)
            {
                case ZombieStimuli.SeeHuman:
                    Debug.WriteLine("Le zombie voit toujours l'humain");
                    break;

                case ZombieStimuli.SeeNothing:
                    Debug.WriteLine("Le zombie ne voit plus l'humain");
                    _zombie.ChangeState(new Walk(_zombie));
                    break;

                case ZombieStimuli.OnHuman:
                    Debug.WriteLine("Le zombie est au contact de l'humain");
                    _zombie.ChangeState(new Attack(_zombie));
                    break;

                default:
                    break;
            }
        }
    }
}
