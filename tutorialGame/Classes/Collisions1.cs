using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace tutorialGame.Classes
{
    class CustomRectangle
    {
        public Vector2 Pos;
        public float Width { get { return _size.X; } set { _size.X = value; } }
        public float Height { get { return _size.Y; } set { _size.Y = value; } }
        public float Rotation { get; set; }
        public Color Color { get; set; }

        private Vector2 _size;
        private float rotation;
        private Color color = Color.White;

        public CustomRectangle(Vector2 pos, Vector2 size, float rotation, Color color)
        {
            this.Pos = pos;
            this._size = size;
            this.rotation = rotation;
            this.color = color;
        }
        public Rectangle ToRectangle()
        {
            return new Rectangle((int)Pos.X, (int)Pos.Y, (int)_size.X,(int)_size.Y);
        }
    }
    internal class Collisions_1
    {
        private CustomRectangle rect1;

        private CustomRectangle rect2;
      
        public Collisions_1()
        {
            rect1 = new CustomRectangle(new Vector2(250, 50), new Vector2(100, 100), 20.0f, Color.White);
            rect2 = new CustomRectangle(new Vector2(455, 50), new Vector2(200, 200), 20.0f, Color.White);
        }
        public void Update(GameTime gameTime, float scale)
        {
            float timepassed = gameTime.ElapsedGameTime.Milliseconds;

            MoveRect(rect1,scale);

            CheckCollision(rect1, rect2);
        }
        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
  
            spriteBatch.DrawRectangle(rect1.ToRectangle(), rect1.Color, 3);
            spriteBatch.DrawRectangle(rect2.ToRectangle(), rect2.Color, 3);
        }


        private void CheckCollision(CustomRectangle rect1, CustomRectangle rect2)
        {
            var length = Math.Abs(rect2.Pos.X- rect1.Pos.X );
            
            var minusValue = rect2.Pos.X > rect1.Pos.X? rect1.Width: rect2.Width;

            var gap_between_boxes = length - minusValue;

            if (gap_between_boxes > 0)
            {
                rect1.Color = Color.White;
            }
            else if (gap_between_boxes <= 0)
            {
                rect1.Color = Color.Red;
            }
            
            Debug.WriteLine(gap_between_boxes);
        }

        private void MoveRect(CustomRectangle rect1,float scale)
        {
            rect1.Pos.X = Mouse.GetState().Position.ToVector2().X / scale -rect1.Width/2;
        }
    }
}
