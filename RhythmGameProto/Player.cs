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
    public class Player : GridSprite
    {
        InputHandler inputHandler;
        
        
        public int PlayerNumber;

        public delegate void InputEventHandler();
        public event InputEventHandler inputEvent;
        public Player(Game game, GridManager gm, int playernumber) : base(game, gm,"MushroomGuy")
        {
            PlayerNumber = playernumber-1;
            gridPos = Vector2.Zero;
            inputHandler = new InputHandler();
            
        }
        public override void Update(GameTime gameTime)
        {
            inputHandler.Update();
            getInput();
            base.Update(gameTime);
        }
        private void getInput()
        {
            if (inputHandler.PressedKey(inputHandler.inputKeys["Right"][PlayerNumber]))
            {
                if(gridPos.X + 1 !< gridManager.gridWidth)
                {
                    if (gridManager.Grid[(int)gridPos.X + 1, (int)gridPos.Y].IsWalkable)
                    {
                        gridPos.X++;
                        inputEvent();
                    }
                }
            }
            if (inputHandler.PressedKey(inputHandler.inputKeys["Left"][PlayerNumber]))
            {
                if(gridPos.X - 1 !> -1)
                {
                    if (gridManager.Grid[(int)gridPos.X - 1, (int)gridPos.Y].IsWalkable)
                    {
                        gridPos.X--;
                        inputEvent();
                    }
                }
            }
            if (inputHandler.PressedKey(inputHandler.inputKeys["Down"][PlayerNumber]))
            {
                if(gridPos.Y + 1 !< gridManager.gridHeight)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y + 1].IsWalkable)
                    {
                        gridPos.Y++;
                        inputEvent();
                    }
                }
            }
            if (inputHandler.PressedKey(inputHandler.inputKeys["Up"][PlayerNumber]))
            {
                if(gridPos.Y - 1 !> -1)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y - 1].IsWalkable)
                    {
                        gridPos.Y--;
                        inputEvent();
                    }
                }
            }
        }

    }
}
