using System.Timers;
using Timer = System.Timers.Timer;

namespace Boggle.Models
{
    public class BlazorTimer
    {
        private Timer _timer;

        internal void SetTimer(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.Enabled = true;
            _timer.Start();
        }

        private void NotifyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnElapsed?.Invoke();
        }

        public event Action OnElapsed;
    }
}
