using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;

namespace Textures_and_Colours
{
    
    public class Game1 : Game
    {
        private int randomXLocation;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bowserTexture; // Used to Draw Bowser
        Texture2D marioTexture;
        Texture2D goombaTexture;
        Texture2D levelTexture;
        Texture2D lakituTexture;
        Texture2D coinTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1200; // Size of Window
            _graphics.PreferredBackBufferHeight = 500; // Height of Window
            _graphics.ApplyChanges();
            this.Window.Title = "Level 1"; // Title of Project when opened
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Random generator = new Random();
            // Place where you put default values. ex health, enemy health etc


            base.Initialize();
            randomXLocation = generator.Next(_graphics.PreferredBackBufferWidth - lakituTexture.Width);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            marioTexture = Content.Load<Texture2D>("LittleMario");
            bowserTexture = Content.Load<Texture2D>("Bowser"); // Bowser DRAWING IT
            goombaTexture = Content.Load<Texture2D>("GoombaDone");
            levelTexture = Content.Load<Texture2D>("LevelFinished");
            lakituTexture = Content.Load<Texture2D>("LakituDone");
            coinTexture = Content.Load<Texture2D>("MarioCoinDone");

            // textures, fonts, ran once when first run program 

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.Red);

            _spriteBatch.Begin();
            _spriteBatch.Draw(levelTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(lakituTexture, new Vector2(randomXLocation, 0), Color.White);
            _spriteBatch.Draw(bowserTexture, new Vector2(870, 180), Color.White); // Default Color of Image is White
            _spriteBatch.Draw(marioTexture, new Vector2(1, 225), Color.White);

            for (int i = 420; i < 650; i+= 90)
            {
                _spriteBatch.Draw(goombaTexture, new Vector2(i, 342), Color.White);
            }

            for (int g = 200; g < 300; g+= 50)
            {
                for (int i = 450; i < 650; i += 50)
                {
                    _spriteBatch.Draw(coinTexture, new Vector2(i, g), Color.White);
                }
            }
            

            _spriteBatch.End();

            // TODO: Add your drawing code here



            base.Draw(gameTime);
        }
    }
}