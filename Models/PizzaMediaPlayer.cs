using Plugin.Maui.Audio;

namespace PizzaTime.Models
{
    internal class PizzaMediaPlayer
    {
        private IAudioPlayer _trackPlayer;

        private PizzaMediaManager _mediaManager;

        public bool IsPlaying 
        { 
            get
            {
                return _trackPlayer.IsPlaying;
            }
        }

        public double Volume
        {
            get
            {
                return _trackPlayer.Volume * 100;
            }

            set
            {
                if (value >= 0 && value <= 100)
                {
                    _trackPlayer.Volume = value / 100;
                }
            }
        }

        public PizzaMediaPlayer(PizzaMediaManager mediaManager)
        {
            _mediaManager = mediaManager;
            _trackPlayer = AudioManager.Current.CreatePlayer(_mediaManager.LoadSelectedTrack());
        }

        public void UpdateTrack()
        {
            if (_trackPlayer.IsPlaying)
            {
                _trackPlayer.Stop();
            }
            _trackPlayer.Dispose();

            _trackPlayer = AudioManager.Current.CreatePlayer(_mediaManager.LoadSelectedTrack());
        }

        public void Play()
        {
            _trackPlayer.Play();
        }

        public void Stop()
        {
            _trackPlayer.Stop();
        }
    }
}
