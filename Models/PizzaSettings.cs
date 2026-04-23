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

        private static int _allTimeNumberOffPizzas = Preferences.Default.Get("AllTimeNumberOffPizzas", 0);
        public static int AllTimeNumberOffPizzas
        {
            get
            {
                return _allTimeNumberOffPizzas;
            }
            set
            {
                Preferences.Default.Set("AllTimeNumberOffPizzas", value);
                _allTimeNumberOffPizzas = value;
            }
        }

        private static int _firstTimer = Preferences.Default.Get("FirstTimer", 40);
        public static int FirstTimer
        {
            get
            {
                return _firstTimer;
            }
            set
            {
                Preferences.Default.Set("FirstTimer", value);
                _firstTimer = value;
            }
        }

        private static int _secondTimer = Preferences.Default.Get("SecondTimer", 30);
        public static int SecondTimer
        {
            get
            {
                return _secondTimer;
            }
            set
            {
                Preferences.Default.Set("SecondTimer", value);
                _secondTimer = value;
            }
        }

        private static int _thirdTimer = Preferences.Default.Get("ThirdTimer", 30);
        public static int ThirdTimer
        {
            get
            {
                return _thirdTimer;
            }
            set
            {
                Preferences.Default.Set("ThirdTimer", value);
                _thirdTimer = value;
            }
        }

        private static int _fourthTimer = Preferences.Default.Get("FourthTimer", 30);
        public static int FourthTimer
        {
            get
            {
                return _fourthTimer;
            }
            set
            {
                Preferences.Default.Set("FourthTimer", value);
                _fourthTimer = value;
            }
        }        
    }
}
