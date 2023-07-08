using System;
using System.Media;
using System.Windows;

namespace timer_mvvm_test
{
    public class TimerModel
    {
        public int TotalSeconds { get; private set; }

        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; } 

        public void SetTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            TotalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        }

        public void Tick()
        {
            if (TotalSeconds > 0)
            {
                TotalSeconds--;
                Hours = TotalSeconds / 3600;
                Minutes = (TotalSeconds % 3600) / 60;
                Seconds = (TotalSeconds % 3600) % 60;

            }
        }

        public bool IsTimerRunning()
        {
            return TotalSeconds > 0;
        }
    }
}