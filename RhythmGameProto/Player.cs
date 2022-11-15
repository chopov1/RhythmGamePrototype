using MacksInterestingMovement;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    internal class Player : Sprite
    {
        InputHandler input;
        GridManager gridManager;
        MonogameTile currentTile;
        Vector2 gridPos;
        public int PlayerNumber;
        public Player(Game game, GridManager gm, int playernumber) : base(game, "MushroomGuy")
        {
            PlayerNumber = playernumber-1;
            gridPos = Vector2.Zero;
            input = new InputHandler();
            gridManager = gm;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            input.Update();
            getInput();
            currentTile = gridManager.Grid[(int)gridPos.X, (int)gridPos.Y];
            Position = currentTile.Position;
        }
        private void getInput()
        {
            if (input.PressedKey(input.inputKeys["Right"][PlayerNumber]))
            {
                if(gridPos.X + 1 !< gridManager.gridWidth)
                {
                    if (gridManager.Grid[(int)gridPos.X + 1, (int)gridPos.Y].IsWalkable)
                    {
                        gridPos.X++;
                    }
                }
            }
            if (input.PressedKey(input.inputKeys["Left"][PlayerNumber]))
            {
                if(gridPos.X - 1 !> -1)
                {
                    if (gridManager.Grid[(int)gridPos.X - 1, (int)gridPos.Y].IsWalkable)
                    {
                        gridPos.X--;
                    }
                }
            }
            if (input.PressedKey(input.inputKeys["Down"][PlayerNumber]))
            {
                if(gridPos.Y + 1 !< gridManager.gridHeight)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y + 1].IsWalkable)
                    {
                        gridPos.Y++;
                    }
                }
            }
            if (input.PressedKey(input.inputKeys["Up"][PlayerNumber]))
            {
                if(gridPos.Y - 1 !> -1)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y - 1].IsWalkable)
                    {
                        gridPos.Y--;
                    }
                }
            }
        }

    }
}
