using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public class GameConditionManager : GameComponent
    {

        GridManager gridManager;
        Player player;
        ArrowIndicators arrowIndicators;

        RhythmManager rm;
        EnemySpawner spawner;
        public GameConditionManager(Game game) : base(game)
        {
            gridManager = new GridManager(Game);
            Game.Components.Add(gridManager);
            player = new Player(Game, gridManager, 1);
            Game.Components.Add(player);
            arrowIndicators = new ArrowIndicators(Game, gridManager, player);
            Game.Components.Add(arrowIndicators);
            rm = new RhythmManager(Game, player);
            spawner = new EnemySpawner(game, gridManager, rm, player);
            Game.Components.Add(spawner);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        private void checkPlayerState()
        {
            if(player.SpriteState == SpriteState.Inactive)
            {
                //build in a buffer of one 1/4 beat of touching the player where they stay alive.
                spawner.spawnState = SpawnState.reset;
                player.ResetPlayer();
                //probobly make this into a state pattern
                rm.stopMusicAndTimer();
                rm.startMusicAndTimer();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            checkPlayerState();
        }
    }
}
