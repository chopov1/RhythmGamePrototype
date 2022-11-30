using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public enum SpawnState { reset, active}
    public class EnemySpawner : GameComponent
    {
        RhythmManager rhythmManager;
        GridManager gridManager;
        Player player;
        Queue<Enemy> enemies;
        int numOfEnemies;
        Random rnd;
        int spawnBuffer;

        public SpawnState spawnState;
        public EnemySpawner(Game game, GridManager gm, RhythmManager rm, Player p) : base(game)
        {
            gridManager = gm;
            rhythmManager = rm;
            player = p;
            numOfEnemies = 8;
            spawnBuffer = 16 * 10;
            rnd = new Random();
            rhythmManager.OnBeat += UpdateSpawner;
            spawnState = SpawnState.active;
        }

        public override void Initialize()
        {
            base.Initialize();
            enemies = createEnemies(numOfEnemies);
            SpawnEnemy();
        }

        public Queue<Enemy> createEnemies(int size)
        {
            Queue<Enemy> objs = new Queue<Enemy>();
            for (int i = 0; i < size; i++)
            {
                Enemy e = new Enemy(Game, gridManager, rhythmManager, player);
                e.Enabled = false;
                e.Visible = false;
                objs.Enqueue(e);
            }
            return objs;
        }

        private void UpdateSpawner()
        {
            if(spawnState == SpawnState.reset)
            {
                resetEnemies();
                spawnState = SpawnState.active;
            }
            SpawnEnemy();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void resetEnemies()
        {
            foreach (Enemy e in enemies)
            {
                e.SpriteState = SpriteState.Inactive;
                e.Enabled = false;
                e.Visible = false;
            }
        }

        int bufferCount;
        private bool checkSpawnBuffer()
        {
            if(bufferCount >= spawnBuffer)
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

        Vector2 temp;
        private void SpawnEnemy()
        {
            if (checkSpawnBuffer())
            {
                if(enemies.Peek().Enabled == false)
                {
                    Enemy enemyToSpawn = enemies.Dequeue();
                    enemies.Enqueue(enemyToSpawn);
                    temp = getRandomPos();
                    while (!canSpawn(temp))
                    {
                        temp = getRandomPos();
                        Debug.WriteLine(temp);
                    }
                    enemyToSpawn.gridPos = temp;
                    enemyToSpawn.SpriteState = SpriteState.Active;
                    enemyToSpawn.Enabled = true;
                    enemyToSpawn.Visible = true;
                }
            }
        }


        private Vector2 getRandomPos()
        {
            Vector2 posToSpawn = new Vector2(rnd.Next(1,gridManager.gridWidth),rnd.Next(1, gridManager.gridHeight));
            return posToSpawn;
        }

        private bool canSpawn(Vector2 posToSpawn)
        {
            if (!gridManager.Grid[(int)posToSpawn.X, (int)posToSpawn.Y].IsWalkable)
            {
                return false;
            }
            if (!awayFromPlayer(posToSpawn))
            {
                return false;
            }
            return true;
        }

        private bool awayFromPlayer(Vector2 posToSpawn)
        {
            if (posToSpawn == player.gridPos)
            {
                return false;
            }
            if (posToSpawn.X < player.gridPos.X -2 || posToSpawn.X > player.gridPos.X + 2)
            {
                if(posToSpawn.Y < player.gridPos.Y -2 || posToSpawn.Y > player.gridPos.Y + 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
