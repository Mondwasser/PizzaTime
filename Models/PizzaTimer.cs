using PizzaTime.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

namespace PizzaTime.Models
{
    internal class PizzaTimer
    {
        readonly Stopwatch _timer;

        private TimeSpan _elapsed;
        public TimeSpan Elapsed
        {
            get => _elapsed;
            set 
            {
                _elapsed = value;
                newTimeStamp?.Invoke();
            }
        }

        public bool IsRunning = false;

        public string ElapsedTime;

        /// <summary>
        /// Called when object was changed in any way
        /// </summary>
        public event Action? newTimeStamp;

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand ClearCommand { get; }

        private string FormatElapsedTime(TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"ss");
        }

        private void Start()
        {
            _timer.Restart();

            IsRunning = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ElapsedTime = FormatElapsedTime(_timer.Elapsed);
                });
                return IsRunning;
            });
        }

        private void Stop()
        {
            _timer.Stop();
            IsRunning = false;
        }

        private void Clear()
        {
            ElapsedTime = "00:00";
        }

        public PizzaTimer()
        {
            _timer = new Stopwatch();
            ElapsedTime = "00:00";
            IsRunning = false;
            StartCommand = new Command(() => Start());
            StopCommand = new Command(() => Stop());
            ClearCommand = new Command(() => Clear());
        }
    }
}
