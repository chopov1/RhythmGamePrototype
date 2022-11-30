using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public enum SpriteState { Active, Inactive }
    public class GridSprite : Sprite
    {
        public SpriteState SpriteState;
        protected GridManager gridManager;
        MonogameTile prevTile;
        protected MonogameTile currentTile;
        public Vector2 gridPos;
        public GridSprite(Game game, GridManager gm, string texturename) : base(game, texturename)
        {
            gridManager = gm;
        }

        public override void Update(GameTime gameTime)
        {
            currentTile = gridManager.Grid[(int)gridPos.X, (int)gridPos.Y];
            Position = currentTile.Position;
            base.Update(gameTime);
        }

        protected void changeTileOccupation()
        {
            prevTile = currentTile;
            prevTile.State = TileState.empty;
            currentTile.State = TileState.occupied;
            prevTile.OnTileStateChange();
            currentTile.OnTileStateChange();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
