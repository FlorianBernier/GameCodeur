using SharpDX.XInput;
using State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Zombie dispose d'un etats / methode Change States et DoSomething(update)
namespace ClassState
{
    public enum ZombieStimuli
    {
        SeeNothing,
        SeeHuman,
        OnHuman
    }
    public class Zombie
    {
        public ZombieStimuli WhatHappen { get; set; } // Simule un stimuli 
        private IZombieState _state;


        public Zombie() 
        {
            WhatHappen = ZombieStimuli.SeeNothing;
            _state = new Walk(this);
        }



        public void ChangeState(IZombieState newState)
        {
            _state = newState;
        }


        public void DoSomething()
        {
            _state.DoSomething();
        }
    }
}
