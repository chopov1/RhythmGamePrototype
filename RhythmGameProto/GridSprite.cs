using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public class GridSprite : Sprite
    {
        protected GridManager gridManager;
        protected MonogameTile currentTile;
        protected Vector2 gridPos;
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
    }
}
