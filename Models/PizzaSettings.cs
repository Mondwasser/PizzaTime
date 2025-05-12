namespace PizzaTime.Models
{
    internal static class PizzaSettings
    {
        public static int NumberOfPizzas { get; set; } = 0;

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
