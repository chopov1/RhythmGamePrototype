using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using SharpDX.XAudio2;

namespace RhythmGameProto
{

    public class RhythmManager : DrawableGameComponent
    {
        public float bpm;
        public float beat;
        float temp;

        OverlordTimer timer;

        Song song;
        string songname;
        string clicktrack;

        SpriteFont font;
        Texture2D noteTexture;
        Texture2D offbeatNote;
        Texture2D downbeatNote;
        Texture2D halfNote;
        SpriteBatch spriteBatch;
        Player player;

        public delegate void RhythmEventHandler();
        public event RhythmEventHandler OnBeat;

        public RhythmManager(Game game, Player player) : base(game)
        {
            this.player = player;
            player.inputEvent += checkInputAccuracy;
            game.Components.Add(this);
            bpm = 82;
            songname = "Synthwave2";
            clicktrack = "clickTrack82bpm";
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
            font = Game.Content.Load<SpriteFont>("Font1");
            offbeatNote = Game.Content.Load<Texture2D>("MusicNoteGrey");
            downbeatNote = Game.Content.Load<Texture2D>("MusicNoteYellow");
            halfNote= Game.Content.Load<Texture2D>("MusicNotePurple");
            noteTexture = offbeatNote;
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            setupMusicAndTimer();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        private void setupMusicAndTimer()
        {
            song = Game.Content.Load<Song>(songname);
            timer = new OverlordTimer(bpm);
        }

        bool hasStarted;
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            checkForBeat();
            //initialize function results in music and timer out of sync
            if(hasStarted == false)
            {
                startMusicAndTimer();
            }
        }

        private void checkForBeat()
        {
            if(timer.TIME == 0)
            {
                if(OnBeat != null)
                {
                    OnBeat();
                }
            }
        }

        private void changeNoteTexture()
        {
            switch (timer.TIME)
            {
                case 0:
                    noteTexture = downbeatNote;
                    break;
                case 2:
                    noteTexture = halfNote;
                    break;
                case 1:
                case 3:
                    noteTexture = offbeatNote;
                    break;
            }
        }

        //maybe make this into a state and check on update weather we need to start or stop the song/timer
        //then these methods can be private again
        public void startMusicAndTimer()
        {
            MediaPlayer.Play(song);
            timer.StartTimer();
            hasStarted = true;
        }

        public void stopMusicAndTimer()
        {
            MediaPlayer.Stop();
            timer.StopTimer();
        }

        private void checkInputAccuracy()
        {
            //check time that player inputed at
            temp = timer.TIME;
            changeNoteTexture();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();
            spriteBatch.Draw(noteTexture, new Vector2(300, 30), Color.White);
            spriteBatch.DrawString(font, timer.TIME.ToString(), new Vector2(10,10), Color.White);
            spriteBatch.DrawString(font, temp.ToString(), new Vector2(200, 10), Color.White);
            spriteBatch.End();
        }


    }
}
