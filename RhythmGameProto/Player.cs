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
        public InputRandomizer inputRandomizer;

        
        public int PlayerNumber;

        public delegate void InputEventHandler();
        public event InputEventHandler inputEvent;
        public Player(Game game, GridManager gm, int playernumber) : base(game, gm,"MushroomGuy")
        {
            PlayerNumber = playernumber-1;
            gridPos = Vector2.Zero;
            inputHandler = new InputHandler();
            inputRandomizer = new InputRandomizer(inputHandler);
        }
        public override void Update(GameTime gameTime)
        {
            inputHandler.Update();
            getRandomInput();
            base.Update(gameTime);
        }
        #region regular input
        private void getNormalInput()
        {
            if (inputHandler.PressedKey(inputHandler.inputKeys["Right"][PlayerNumber]))
            {
                if (gridPos.X + 1! < gridManager.gridWidth)
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
                if (gridPos.X - 1! > -1)
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
                if (gridPos.Y + 1! < gridManager.gridHeight)
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
                if (gridPos.Y - 1! > -1)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y - 1].IsWalkable)
                    {
                        gridPos.Y--;
                        inputEvent();
                    }
                }
            }
        }
        #endregion

        //right left down up
        bool shuffle;
        private void getRandomInput()
        {
            //TODO refactor all this into switch statement
            if (inputHandler.PressedKey(inputRandomizer.InputKeys[inputRandomizer.Indicies[0]][PlayerNumber]))
            {
                if (gridPos.X + 1! < gridManager.gridWidth)
                {
                    if (gridManager.Grid[(int)gridPos.X + 1, (int)gridPos.Y].IsWalkable)
                    {
                        gridPos.X++;
                        inputEvent();
                        shuffle = true;
                    }
                }
            }
            if (inputHandler.PressedKey(inputRandomizer.InputKeys[inputRandomizer.Indicies[1]][PlayerNumber]))
            {
                if (gridPos.X - 1! > -1)
                {
                    if (gridManager.Grid[(int)gridPos.X - 1, (int)gridPos.Y].IsWalkable)
                    {
                        gridPos.X--;
                        inputEvent();
                        shuffle = true;
                    }
                }
            }
            if (inputHandler.PressedKey(inputRandomizer.InputKeys[inputRandomizer.Indicies[2]][PlayerNumber]))
            {
                if (gridPos.Y + 1! < gridManager.gridHeight)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y + 1].IsWalkable)
                    {
                        gridPos.Y++;
                        inputEvent();
                        shuffle = true;
                    }
                }
            }
            if (inputHandler.PressedKey(inputRandomizer.InputKeys[inputRandomizer.Indicies[3]][PlayerNumber]))
            {
                if (gridPos.Y - 1! > -1)
                {
                    if (gridManager.Grid[(int)gridPos.X, (int)gridPos.Y - 1].IsWalkable)
                    {
                        gridPos.Y--;
                        inputEvent();
                        shuffle = true;
                    }
                }
            }
            if (shuffle)
            {
                inputRandomizer.Indicies = inputRandomizer.shuffleKeys(inputRandomizer.Indicies);
                shuffle = false;
            }
            /*foreach(var i in inputRandomizer.Indicies)
            {
                Debug.WriteLine($"the number at index {i} is {inputRandomizer.Indicies[i]}");
            }*/
            /*Debug.WriteLine(" key that will move down -> " + inputRandomizer.InputKeys[inputRandomizer.Indicies[2]][PlayerNumber]);
            Debug.WriteLine(" the third number in the index list is " + inputRandomizer.Indicies[2]);*/
        }
    }
}
