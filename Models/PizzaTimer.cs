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

        private string _elapsedTime;
        public string ElapsedTime
        { 
            get => _elapsedTime;
            set
            {
                _elapsedTime = value;
                newTimeStamp?.Invoke();
            }
        }

        private int _phaseTime = TimerSettings.GetCurrentPhaseTime();
        public int PhaseTime
        {
            get { return _phaseTime; }
            set 
            { 
                _phaseTime = value;
                ElapsedTime = value.ToString();
            }
        } 

        public event Action? newTimeStamp;

        public event Action? phaseDone;

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand PauseCommand { get; }

        private void Start()
        {
            _timer.Start();
            IsRunning = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            {
                OnTimerCheck();
                return IsRunning;
            });
        }

        private void Stop()
        {
            _timer.Stop();
            _timer.Reset();
            ElapsedTime = _phaseTime.ToString();
            IsRunning = false;
        }

        private void Pause()
        {
            _timer.Stop();
            IsRunning = false;
        }

        private void OnTimerCheck()
        {
            int remainingTime = _phaseTime - _timer.Elapsed.Seconds;
            if (remainingTime <= 0)
            {
                _timer.Stop();
                _timer.Reset();
                ElapsedTime = "0";
                IsRunning = false;
                phaseDone?.Invoke();
            }
            else
            {
                ElapsedTime = remainingTime.ToString();
            }
        }

        public PizzaTimer()
        {
            _timer = new Stopwatch();
            ElapsedTime = PhaseTime.ToString();
            IsRunning = false;
            StartCommand = new Command(() => Start());
            StopCommand = new Command(() => Stop());
            PauseCommand = new Command(() => Pause());
        }
    }
}
