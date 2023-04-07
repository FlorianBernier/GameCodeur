using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TowerDefence
{
    public class TimerMiliseconde
    {

        private int miliseconds;
        private long currentMs;
        public bool hasStart = true;

        public TimerMiliseconde(int pMs)
        {
            miliseconds = pMs;
            currentMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public bool elapsed()
        {
            return currentMs + miliseconds < DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void restart()
        {
            hasStart = true;
            currentMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void stop()
        {
            hasStart = false;
        }

        public void changeTimer(int pMs) 
        {
            miliseconds = pMs;
        }

    }
}
