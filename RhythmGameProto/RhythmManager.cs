using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public class RhythmManager : GameComponent
    {
        public float bpm;

        OverlordTimer timer;

        public RhythmManager(Game game) : base(game)
        {
            timer = new OverlordTimer();
        }


    }
}
