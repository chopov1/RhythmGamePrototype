using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
   
    public class Enemy : GridSprite
    {
        GridManager gridManager;
        RhythmManager rhythmManager;
        Player player;
        Random rnd;

        int moveBuffer;

        public Enemy(Game game, GridManager gm, RhythmManager rm, Player p) : base(game,gm,"EnemySkull")
        {
            gridManager = gm;
            rhythmManager = rm;
            moveBuffer = 8 * 2;
            rhythmManager.OnBeat += moveEnemy;
            player = p;
            rnd = new Random();
            Game.Components.Add(this);
        }

        int bufferCount;
        private bool checkIfMove()
        {
            if(bufferCount >= moveBuffer)
            {
                bufferCount = 0;
                return true;
            }
            else
            {
                bufferCount++;
            }
            return false;
        }

        private bool isTouchingPlayer()
        {
            if(this.gridPos == player.gridPos && this.Visible == true)
            {
                return true; 
            }
            return false;
        }

        private void checkPlayerPos()
        {
            if (isTouchingPlayer())
            {
                player.SpriteState = SpriteState.Inactive;
            }
        }

        private void moveEnemy()
        {
            if (checkIfMove())
            {
                int dirToMove = rnd.Next(0, 2);
                switch (dirToMove)
                {
                    case 0:
                        moveX();
                        break;
                    case 1:
                        moveY();
                        break;
                }
            }
           checkPlayerPos();
        }

        private void moveY()
        {
            if (this.gridPos.Y > player.gridPos.Y)
            {
                gridPos.Y--;
            }
            else if(this.gridPos.Y == player.gridPos.Y)
            {
                moveX();
            }
            else
            {
                gridPos.Y++;
            }
        }
        private void moveX()
        {
            if (this.gridPos.X > player.gridPos.X)
            {
               gridPos.X--;
            }
            else if (this.gridPos.X == player.gridPos.X)
            {
                if(this.gridPos == player.gridPos)
                {
                    return;
                }
                else
                {
                    moveY();
                }
            }
            else
            {
                gridPos.X++;
            }
        }

    }
}
