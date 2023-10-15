using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;

namespace tutorialGame
{
    internal class Player
    {
        private Texture2D _merasmus;
        
        private Vector2 Position;

        private Vector2 velocity;

        private Vector2 movement ;

        private float _run_acceleration = 1.1f;
        private float _max_run_speed = 4;
        public string keyQ = "Run";
        public string keyW = "keyW/Jump";
        public string keyE = "keyE/Attack";
        public string keyR = "keyR/Special";
        
        /**
        public ContentManager Content
        {
            get { return content; }
        }
        ContentManager content;*/

        public Player(ContentManager content)
        {
            Position = new Vector2(200, 200);
            velocity.X = 2;
            velocity.Y = 0;
           
            LoadContent(content);
        }

        public void LoadContent(ContentManager content)
        {
            _merasmus = content.Load<Texture2D>("merasmus-noback");
        }
        public void Update(KeyboardState keyboardState,GameTime time)
        {
            GetInput(keyboardState);
            ApplyPhysics(time);

        }
        private void GetInput(KeyboardState keyState)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            string commands = string.Empty;

            movement = new Vector2(gamePadState.ThumbSticks.Left.X, gamePadState.ThumbSticks.Left.Y);

            if (keyState.IsKeyDown(Keys.Right))
            {
                movement.X = -1.0f;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                movement.X = 1.0f;
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                movement.Y = 1.0f;
            }
            else if (keyState.IsKeyDown(Keys.Down)) {
                movement.Y = -1.0f;
            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                commands += keyQ;
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                commands += keyW;
            }
            if (keyState.IsKeyDown(Keys.E))
            {
                commands += keyE;
            }
            if (keyState.IsKeyDown(Keys.R))
            {
                commands += keyR;
            }

            if (commands.Contains("Run"))
            {
                velocity.X *=_run_acceleration;
                velocity.Y *=_run_acceleration;
                if(velocity.X > _max_run_speed) velocity.X = _max_run_speed;
                if(velocity.Y > _max_run_speed) velocity.Y = _max_run_speed;
            }
            else
            {
                velocity.X = 2;
                velocity.Y = 2;
            }
        }

        private void ApplyPhysics(GameTime time)
        {
            float timepassed = time.ElapsedGameTime.Milliseconds;
            float x_acceleration = 2f;
            if (Math.Abs(movement.X) > 0.5 && Math.Abs(movement.Y) > 0.5)
            {
                movement.Normalize();
            }
            Position.X += movement.X * velocity.X * timepassed;
            Position.Y += movement.Y * velocity.Y * timepassed;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_merasmus, Vector2.One, null, Color.White, 0, Position, 0.5f, SpriteEffects.None, 0f);
        }
    }
}
