using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using tutorialGame.Classes;

namespace tutorialGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D _renderTarget;
        private Texture2D _background_celeste;
        public float scale = 0.44444f;
        private Player _player;
        private Collisions_1 _collisions1;
        private MouseState prevMouseState;
        private Texture2D _cursor;
        private Vector2 cursorPos = Vector2.Zero;

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _player = new Player(Content);
            _collisions1 = new Collisions_1();
            base.Initialize();
            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0f);
            IsFixedTimeStep = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background_celeste = Content.Load<Texture2D>("Images/Backgrounds/celeste-mountain");
            _renderTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080);
            _cursor = Content.Load<Texture2D>("Images/cursor");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyState = Keyboard.GetState();
            _player.Update(keyState,gameTime);
            // TODO: Add your update logic here
            MouseState mouseState = Mouse.GetState();

            
            cursorPos = mouseState.Position.ToVector2() / scale;
            if(mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {

            }
            _collisions1.Update(gameTime,scale);
            
            prevMouseState = mouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            scale = 1F / (1080f / _graphics.GraphicsDevice.Viewport.Height);

            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background_celeste, Vector2.One, null, Color.Pink);

            //_spriteBatch.Draw(_cursor, cursorPos, Color.White);
            //_player.Draw(_spriteBatch);
            _collisions1.Draw(_graphics.GraphicsDevice, _spriteBatch);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget,Vector2.Zero,null,Color.White,0f,Vector2.Zero,scale,SpriteEffects.None,0f);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}