using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutorialGame.Classes
{
    internal class Collisions_1
    {
        private Vector2 posRect1 = new Vector2(25, 50);
        private int size1 = 200;
        private float rotation1 = 20.0f;

        private Vector2 posRect2 = new Vector2(455, 50);
        private int size2 = 200;
        private float rotation2 = 20.0f;
        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {

            spriteBatch.DrawRectangle(new Rectangle((int)posRect1.X, (int)posRect1.Y, size1, size1), Color.White, 3);
            spriteBatch.DrawRectangle(new Rectangle((int)posRect2.X, (int)posRect2.Y, size2, size2), Color.White, 3);
        }
    }
}
