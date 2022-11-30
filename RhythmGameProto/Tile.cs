using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RhythmGameProto
{
    public enum TileState { empty, occupied}
    public class Tile
    {
        public bool IsWalkable;
        public TileState state;
        public TileState prevTileState;
        public Vector2 tilePos;
         
        public Tile(Vector2 pos)
        {
            tilePos = pos;
            state = TileState.empty;
        }

        public virtual void OnTileStateChange()
        {
            prevTileState = state;
        }

        public virtual void tileUpdate()
        {
            
        }
    }
}
