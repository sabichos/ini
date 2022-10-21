using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Ini_1._0
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Ini : Microsoft.Xna.Framework.Game
    {
        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;
        Cue backgroundMusic;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        clsSprite ball1;
        clsSprite ball2;


        public Ini()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 300;
            graphics.PreferredBackBufferWidth = 500;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            audioEngine = new AudioEngine("Content\\IniSounds.xgs");
            waveBank = new WaveBank(audioEngine, "Content\\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, "Content\\Sound Bank.xsb");
            //backgroundMusic = soundBank.GetCue("Mood");
            //backgroundMusic.Play();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            ball1 = new clsSprite(Content.Load<Texture2D>("ball"), new Vector2(0f, 0f), 
                new Vector2(64f, 64f),graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight);
            ball2 = new clsSprite(Content.Load<Texture2D>("ball"), new Vector2(80f, 80f),
                new Vector2(64f, 64f), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            ball1.Velocity = new Vector2(1, 1);
            ball1.position += new Vector2(1f, 0f);

            //ball2.Velocity = new Vector2(-3, 3);
            //ball2.position += new Vector2(-3f, 3f);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            ball1.Dispose();
            ball2.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            ball1.Move();
           //KeyboardMove(ball2);
            MouseMove(ball2);
            //ball2.Move();
            if (ball1.Collides(ball2))
            {
                ball1.Velocity *= -1;
                //soundBank.PlayCue("chord");
                //Vector2 temp = ball2.Velocity;
                //ball2.Velocity = ball1.Velocity;
                //ball1.Velocity = temp;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ball1.Draw(spriteBatch);
            ball2.Draw(spriteBatch);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        public void KeyboardMove(clsSprite ball)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
                ball.position += new Vector2(0,-5);
            if (keyboardState.IsKeyDown(Keys.Down))
                ball.position += new Vector2(0, 5);
            if (keyboardState.IsKeyDown(Keys.Left))
                ball.position += new Vector2(-5, 0);
            if (keyboardState.IsKeyDown(Keys.Right))
                ball.position += new Vector2(5, 0);
        }
        public void MouseMove(clsSprite ball)
        {
            MouseState mouseState = Mouse.GetState();
            if (ball.position.X < mouseState.X)
                ball.position += new Vector2(5,0);
            if (ball.position.X > mouseState.X)
                ball.position += new Vector2(-5, 0);
            if (ball.position.Y < mouseState.Y)
                ball.position += new Vector2(0, 5);
            if (ball.position.Y > mouseState.Y)
                ball.position += new Vector2(0, -5);

        }
    }
}
