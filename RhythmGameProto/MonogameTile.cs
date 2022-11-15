using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RhythmGameProto
{
    public class MonogameTile : Sprite
    {
        public bool IsWalkable;
        Tile tile;
        public MonogameTile(Game game, string texture, bool isWalkable) : base(game, texture)
        {
            tile = new Tile();
            IsWalkable = isWalkable;
            Game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void checkState()
        {
            switch (tile.state)
            {
                case TileState.empty:
                    break;
                case TileState.occupied:
                    break;
            }
        }
        
    }
}
