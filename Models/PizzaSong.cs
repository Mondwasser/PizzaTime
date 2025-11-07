using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.Models
{
    internal class PizzaSong
    {
        public string TrackName;
        public string TrackPath;
        public bool IsStandardTrack;

        public PizzaSong(string trackName, string trackPath, bool isStandardTrack)
        {
            TrackName = trackName;
            TrackPath = trackPath;
            IsStandardTrack = isStandardTrack;
        }
    }
}
