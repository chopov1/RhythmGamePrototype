using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public class Enemy : GridSprite
    {
        public Enemy(Game game, GridManager gm) : base(game,gm,"EnemySkull")
        {

        }

    }
}
