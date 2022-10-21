using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ini_1._0
{
    public class clsSprite
    {
        public Texture2D texture { get; set; }
        public Vector2 position {get; set;}
        public Vector2 size {get; set;}
        public Vector2 ScreenSize { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Center { get {return position + (size/2); } }
        public float Radius { get {return size.X/2 ;} }


      

        public clsSprite(Texture2D texture, Vector2 position, Vector2 size,int screenWidth, int screenHeight)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            this.ScreenSize = new Vector2(screenWidth,screenHeight);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }
        public void Move()
        {
            if (position.X + size.X + Velocity.X > ScreenSize.X)
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            if (position.Y + size.Y + Velocity.Y > ScreenSize.Y)
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            if (position.X + Velocity.X < 0)
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            if (position.Y + Velocity.Y < 0)
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            position += Velocity;
        }
        public bool Collides(clsSprite ball2)
        {
            //for circles
            return (Vector2.Distance(this.Center,ball2.Center) < (this.Radius + ball2.Radius));
                


            /*
            //For squares
            if (this.position.X + this.size.X > ball2.position.X &&
                this.position.Y + this.size.Y > ball2.position.Y &&
                ball2.position.X + ball2.size.X > this.position.X &
                ball2.position.Y + ball2.size.Y > this.position.Y)
                return true;
            return false;
             */ 
            {

            }
        }
        public void Dispose()
        {
            texture.Dispose();
        }
    }
}
