using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Char.Content.Sprites
{
    public class Player : Sprite
    {
        bool jumping;
        public Player(Texture2D texture)
        
      : base(texture)
        {
            
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
           


            Move();

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                    this.Velocity.X = 0;

                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                    this.Velocity.Y = 0;

            }

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        private void Move()
        {
            

            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X =  -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;
            else Velocity.X = 0;

            if (Keyboard.GetState().IsKeyDown(Input.Space) && jumping == false)
            {
                Velocity.Y -= 10f ;
                Position.Y = -5f ;
                jumping = true;
            }
            if (jumping == true) 
            {
                float i = 1;
                Velocity.Y += 2f * i;
            }
            if(Position.Y + _texture.Height >= 120)
            {
                jumping = false;
            }
            if(jumping == false)
            {
                Velocity.Y = 0f;
            }
                

        }
    }
}
