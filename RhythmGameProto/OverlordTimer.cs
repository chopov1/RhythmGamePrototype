using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace RhythmGameProto
{
    internal class OverlordTimer
    {
        private System.Timers.Timer aTimer;
        public DateTime currentTime;
        public OverlordTimer()
        {
            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 5;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;

            Debug.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }
       
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //change this to debug writeline to check if its working
            Debug.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            currentTime = e.SignalTime;
        }
    }
}
