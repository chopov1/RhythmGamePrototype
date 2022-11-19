using MacksInterestingMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public class ArrowIndicators : DrawableGameComponent
    {
        GridSprite leftArrow;
        GridSprite rightArrow;
        GridSprite topArrow;
        GridSprite bottomArrow;
        List<GridSprite> arrows;
        Player player;
        GridManager gridManager;
        public ArrowIndicators(Game game, GridManager gm,Player player) : base(game)
        {
            gridManager = gm;
            this.player = player;
            arrows = new List<GridSprite>();
            rightArrow = new GridSprite(game, gm, "ArrowRight");
            arrows.Add(rightArrow);
            leftArrow = new GridSprite(game, gm, "ArrowLeft");
            arrows.Add(leftArrow);
            bottomArrow = new GridSprite(game, gm, "ArrowDown");
            arrows.Add(bottomArrow);
            topArrow = new GridSprite(game, gm, "ArrowUp");
            arrows.Add(topArrow);
            setupArrows();
        }
        private void setupArrows()
        {
            foreach(var arrow in arrows)
            {
                Game.Components.Add(arrow);
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            setPositions();
        }
        public void setPositions()
        {
            //check what key is at what index
            //i know the direction each index points to, so I just need to find out what key
            //it is and set that arrows pos to that tile
            //make sure to check if tile is walkable or exists
            for(int i =0; i < arrows.Count; i++)
            {
                checkKeys(arrows[i],i);

            }
            Debug.WriteLine("------------");
        }
        //right left down up
        private void checkKeys(GridSprite arrow, int loopCount)
        {
            Debug.WriteLine($"Arrows at {loopCount} is {arrows[loopCount].TextureName}. Indicies at {loopCount} is {player.inputRandomizer.Indicies[loopCount]}.");
            
            switch (player.inputRandomizer.Indicies[loopCount])
            {
                case 0:
                    if (player.gridPos.X + 1! < gridManager.gridWidth)
                    {
                        if (gridManager.Grid[(int)player.gridPos.X + 1, (int)player.gridPos.Y].IsWalkable)
                        {
                            arrow.gridPos = new Vector2(player.gridPos.X + 1, player.gridPos.Y);
                            arrow.Visible = true;
                        }
                        else
                        {
                            arrow.Visible = false;
                        }
                    }
                    else
                    {
                        arrow.Visible = false;
                    }
                    break;
                case 1:
                    if (player.gridPos.X - 1! > -1)
                    {
                        if (gridManager.Grid[(int)player.gridPos.X - 1, (int)player.gridPos.Y].IsWalkable)
                        {
                            arrow.gridPos = new Vector2(player.gridPos.X - 1, player.gridPos.Y);
                            arrow.Visible = true;
                        }
                        else
                        {
                            arrow.Visible = false;
                        }
                    }
                    else
                    {
                        arrow.Visible = false;
                    }
                    break;
                case 2:
                    if (player.gridPos.Y + 1! < gridManager.gridHeight)
                    {
                        if (gridManager.Grid[(int)player.gridPos.X, (int)player.gridPos.Y + 1].IsWalkable)
                        {
                            arrow.gridPos = new Vector2(player.gridPos.X, player.gridPos.Y + 1);
                            arrow.Visible = true;
                        }
                        else
                        {
                            arrow.Visible = false;
                        }
                    }
                    else
                    {
                        arrow.Visible = false;
                    }
                    break;
                case 3:
                    if (player.gridPos.Y - 1! > -1)
                    {
                        if (gridManager.Grid[(int)player.gridPos.X, (int)player.gridPos.Y - 1].IsWalkable)
                        {
                            arrow.gridPos = new Vector2(player.gridPos.X, player.gridPos.Y - 1);
                            arrow.Visible = true;
                        }
                        else
                        {
                            arrow.Visible = false;
                        }
                    }
                    else
                    {
                        arrow.Visible = false;
                    }
                    break;
            }
        }

        private void setArrows()
        {
            for(int i =0; i < player.inputRandomizer.Indicies.Length; i++)
            {

            }
        }
    }
}
