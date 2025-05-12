using Plugin.Maui.Audio;

namespace PizzaTime.Models
{
    internal class PizzaMediaPlayer
    {
        private IAudioPlayer trackPlayer;

        public bool IsPlaying 
        { 
            get
            {
                return trackPlayer.IsPlaying;
            }
        }
        public double Volume
        {
            get
            {
                return trackPlayer.Volume * 100;
            }

            set
            {
                if (value >= 0 && value <= 100)
                {
                    trackPlayer.Volume = value / 100;
                }
            }
        }

        public void Play()
        {
            trackPlayer.Play();
        }

        public void Stop()
        {
            trackPlayer.Stop();
        }

        public PizzaMediaPlayer() 
        {
            IAudioManager manager = AudioManager.Current;
            Stream track = FileSystem.OpenAppPackageFileAsync("tarantella-napoletana-164475.mp3").Result;
            trackPlayer = manager.CreatePlayer(track);
        }
    }
}
