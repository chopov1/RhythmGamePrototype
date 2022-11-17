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
        public float TIME;

        float bpm;

        double resetVal;
        public OverlordTimer(float bpm)
        {
            this.bpm = bpm;
            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = getInterval(bpm);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            

        }
        public void StartTimer()
        {
            aTimer.Enabled = true;
        }
        private double getInterval(float bpm)
        {
            int div = 4;
            double interval = Math.Round((60000/bpm)/div, 0);
            resetVal = div;
            Debug.WriteLine(interval);
            return interval;
        }
       
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            currentTime = e.SignalTime;
            TIME++;
            if(TIME >= resetVal)
            {
                TIME = 0;
            }
            /*if(TIME >= float.MaxValue)
            {
                TIME = 0;
            }*/
        }
    }
}
