namespace PizzaTime.Models
{
    internal static class PizzaSettings
    {
        private static int _numberOfPhases = Preferences.Default.Get("NumberOfPhases", 4);
        public static int NumberOfPhases
        {
            get
            {
                return _numberOfPhases;
            }
            set
            {
                if (_numberOfPhases != value && _numberOfPhases <= 4 && _numberOfPhases >= 1)
                {
                    Preferences.Default.Set("NumberOfPhases", value);
                    _numberOfPhases = value;
                }
            }
        }

        // Name constants for Preferences

        private static readonly string _allTimeNumberOffPizzasName = "AllTimeNumberOffPizzas";
        private static readonly string _FirstTimerName = "FirstTimer";
        private static readonly string _SecondTimerName = "SecondTimer";
        private static readonly string _ThirdTimerName = "ThirdTimer";
        private static readonly string _FourthTimerName = "FourthTimer";

        public const string StandardTrackName = "Standard Track"; 
        public const string StandardTrackPath = "tarantella-napoletana-164475.mp3";

        public static int _curentNumberOfPizzas = 0;
        public static int CurentNumberOfPizzas 
        { 
            get
            {
                return _curentNumberOfPizzas;
            }
            set
            {
                AllTimeNumberOffPizzas += value - _curentNumberOfPizzas;
                _curentNumberOfPizzas = value;
            }
        }

        private static int _allTimeNumberOffPizzas = Preferences.Default.Get(_allTimeNumberOffPizzasName, 0);
        public static int AllTimeNumberOffPizzas
        {
            get
            {
                return _allTimeNumberOffPizzas;
            }
            set
            {
                Preferences.Default.Set(_allTimeNumberOffPizzasName, value);
                _allTimeNumberOffPizzas = value;
            }
        }

        private static int _firstTimer = Preferences.Default.Get(_FirstTimerName, 40);
        public static int FirstTimer
        {
            get
            {
                return _firstTimer;
            }
            set
            {
                Preferences.Default.Set(_FirstTimerName, value);
                _firstTimer = value;
            }
        }

        private static int _secondTimer = Preferences.Default.Get(_SecondTimerName, 30);
        public static int SecondTimer
        {
            get
            {
                return _secondTimer;
            }
            set
            {
                Preferences.Default.Set(_SecondTimerName, value);
                _secondTimer = value;
            }
        }

        private static int _thirdTimer = Preferences.Default.Get(_ThirdTimerName, 30);
        public static int ThirdTimer
        {
            get
            {
                return _thirdTimer;
            }
            set
            {
                Preferences.Default.Set(_ThirdTimerName, value);
                _thirdTimer = value;
            }
        }

        private static int _fourthTimer = Preferences.Default.Get(_FourthTimerName, 30);
        public static int FourthTimer
        {
            get
            {
                return _fourthTimer;
            }
            set
            {
                Preferences.Default.Set(_FourthTimerName, value);
                _fourthTimer = value;
            }
        }

    }
}
