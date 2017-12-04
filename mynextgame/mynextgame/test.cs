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


namespace mynextgame
{
    class test
    {
        Vector2 lol = new Vector2 (90f);
        Vector2 facingPoint;
        Vector2 position;
        float tan;
        float rotation;
        float angle;
       public test ()
        {


        }
        public void update()
        {
            //angle = (float)Math.Atan2(lol.X, lol.Y);
                      
            KeyboardState ks = Keyboard.GetState();

            facingPoint = new Vector2((float)Math.Cos(lol.X), (float)Math.Sin(lol.X));
            facingPoint.Normalize();
            // position += facingPoint * 5;
            //angle *= (float) (180 / Math.PI);
            // angle =   Math.Abs(angle) % 90;
            // Math.Tan(angle* (float)(Math.PI/180));
            tan = (float) Math.Atan2(facingPoint.Y, facingPoint.X);
            // angle =(float) Math.Tan(lol.X );
            // degrees = radians * (180 / pi)
            // radians = degrees * (pi / 180)



            if (ks.IsKeyDown(Keys.A))
            {
                //rotation += 0.1f;
                lol.X--;


            }
          
            if (ks.IsKeyDown(Keys.D))
            {

                //rotation -= 0.1f;
                lol.X++;
            }
            if( ks. IsKeyDown(Keys.W))
            {
                lol.Y++;
            }
            if( ks. IsKeyDown (Keys.S))
            {
                lol.Y--;
            }

        
         
        }

        public void  write (SpriteBatch spriteBatch, SpriteFont writing)
        {
            spriteBatch.DrawString(writing, $"angle: {facingPoint.X}, {facingPoint.Y}% ", new Vector2 (100,100), Color.White);
            spriteBatch.DrawString(writing, $"lol x: {lol.X}% ", new Vector2(500, 100), Color.AliceBlue);
            spriteBatch.DrawString(writing, $": {tan}% ", new Vector2(500, 300), Color.White);
            spriteBatch.DrawString(writing, $"lol y: {lol.Y}% ", new Vector2(500, 200), Color.White);
        }
    }
}
