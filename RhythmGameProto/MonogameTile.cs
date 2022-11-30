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
        public bool IsWalkable { get { return tile.IsWalkable; } }
        public TileState State { get { return tile.state; } set { tile.state = value; } }
        public TileState prevState { get { return tile.prevTileState; } set { tile.prevTileState = value; } }

        Tile tile;
        public MonogameTile(Game game, string texture, bool isWalkable, Tile t) : base(game, texture)
        {
            tile = t;
            tile.IsWalkable = isWalkable;
            Game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            tile.tileUpdate();
        }

        public void OnTileStateChange()
        {
            tile.OnTileStateChange();
            if (tile.IsWalkable)
            {
                //change texture to walkable
            }
            else
            {
                //change texture to unwalkable
            }
        }
        
    }
}
