using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
