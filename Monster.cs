using _321_Lab05_3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap
{
    internal class Monster
    {
        private int speed;
        private AnimatedTexture anim = new AnimatedTexture(Vector2.Zero, 0, 1, 0);
        private Vector2 monster_pos,target,bound1,bound2;                  //ขอบที่มอนส์เตอร์จะวิ่งไปมา
        private Rectangle hitbox;
        private Vector2 hitbox_size = new Vector2(64,64);          //ขนาด hitbox
        public Monster(ContentManager Content,Texture2D asset, int frameCount, int frameRow, int framesPerSec, int startRow, Vector2 bound1,Vector2 bound2,int speed)
        {
            anim.Load(Content, asset, frameCount, frameRow, framesPerSec, startRow, 1);
            this.bound1 = bound1;
            this.bound2 = bound2;
            this.speed = speed;
            monster_pos = bound1;
            target = bound2;
        }


        public void update(float elapsed)
        {
            hitbox = new Rectangle((int)monster_pos.X, (int)monster_pos.Y, (int)hitbox_size.X, (int)hitbox_size.Y);
            if(bound1.X % speed != 0)
            {
                bound1.X += 1;
            }
            if (bound2.X % speed != 0)
            {
                bound2.X += 1;
            }
            if (bound1.Y % speed != 0)
            {
                bound1.Y += 1;
            }
            if (bound2.Y % speed != 0)
            {
                bound2.Y += 1;
            }


            anim.UpdateFrame(elapsed);
            if(monster_pos.X < target.X)
            {
                monster_pos.X += speed;
                anim.startrow = 4;
            }
            else if(monster_pos.X > target.X)
            {
                monster_pos.X -= speed;
                anim.startrow = 3;
            }
            if(monster_pos.Y < target.Y)
            {
                monster_pos.Y += speed;
                anim.startrow = 1;
            }
            else if(monster_pos.Y > target.Y)
            {
                monster_pos.Y -= speed;
                anim.startrow = 2;
            }

            if(monster_pos == bound1)
            {
                target = bound2;
            }
            else if(monster_pos == bound2)
            {
                target = bound1;
            }

        }
        public bool monster_with_player(Rectangle player_hitbox)
        {
            if (hitbox.Intersects(player_hitbox))
            {
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch _batch)
        {
            anim.DrawFrame(_batch, monster_pos);
        }
    }
}
