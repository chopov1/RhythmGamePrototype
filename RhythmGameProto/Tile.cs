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
        public TileState state;
        public Tile()
        {
            state = TileState.empty;
        }

        public void tileUpdate()
        {
            switch (state)
            {
                case TileState.empty:
                    break;
                case TileState.occupied:
                    break;
            }
        }
    }
}
