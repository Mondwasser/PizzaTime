using System.Diagnostics;
using System.Windows.Input;

namespace PizzaTime.Models
{
    internal class PizzaTimer
    {
        readonly Stopwatch _timer;

        private int _currentPhase = 1;
        public int CurrentPhase
        {
            get => _currentPhase;
            set
            {
                _currentPhase = value;
                ElapsedTime = GetCurrentPhaseTime().ToString();
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

        private int _phaseTime = PizzaSettings.FirstTimer;

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
                if (IsRunning)
                {
                    ElapsedTime = remainingTime.ToString();
                }
            }
        }

        public PizzaTimer()
        {
            _timer = new Stopwatch();
            ElapsedTime = _phaseTime.ToString();
            IsRunning = false;
            StartCommand = new Command(() => Start());
            StopCommand = new Command(() => Stop());
            PauseCommand = new Command(() => Pause());
        }

        public int GetCurrentPhaseTime()
        {
            switch (_currentPhase)
            {
                case 1: return PizzaSettings.FirstTimer;
                case 2: return PizzaSettings.SecondTimer;
                case 3: return PizzaSettings.ThirdTimer;
                case 4: return PizzaSettings.FourthTimer;
                default: return -1;
            }
        }
    }
}
