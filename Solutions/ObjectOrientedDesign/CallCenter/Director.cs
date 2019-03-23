using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Solutions.ObjectOrientedDesign.CallCenter
{
    class Director : Employee
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public Call CallToHandle { get; set; }

        public void HandleCall(Call call)
        {
            CallToHandle = call;
            IsBusy = true;
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = call.estimatedTime * 1000;
            timer.Enabled = true;
            timer.Stop();
            timer.Dispose();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            IsBusy = false;
            CallToHandle = null;
        }
    }
}
