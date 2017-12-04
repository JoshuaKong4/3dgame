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
    class draw
    {
        List<Rectangle> pixel;
        //protected int position;
        protected float Angle = MathHelper.PiOver2;

        protected int coordinate = 720;
        protected float distance = 10;

        float actuali;
        
        float iterations;
        protected bool xory;
        public draw()
        {
            pixel = new List<Rectangle>();

        }

        public void update()
        {
        
          
           
          
        
                actuali = distance * (float)Math.Sin(Angle);
            
            pixel.Clear();
            pixel = new List<Rectangle>();
            for (int i = 0; i < actuali; i++)
            {
                iterations = (i - actuali / 2);
            

                
                pixel.Add(new Rectangle((int)(coordinate + iterations), 200 - ((int)(distance + iterations * Math.Cos(Angle))) / 2, 1, (int)(distance + iterations * Math.Cos(Angle))));
                
            }
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.W))
            {
                distance++;

            }
            if (ks.IsKeyDown(Keys.A))
            {
                Angle += 0.1f;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                distance--;

            }
            if (ks.IsKeyDown(Keys.D))
            {
                Angle -= 0.1f;

            }
            if (ks.IsKeyDown(Keys.K))
            {
                coordinate--;

            }
            if (ks.IsKeyDown(Keys.L))
            {
                coordinate++;

            }

        }
    
        public void sketch(SpriteBatch spriteBatch, Texture2D txt, Color tnt, SpriteFont textfont)
        {
           
            for (int i = 0; i< pixel.Count; i++)
            {
                spriteBatch.Draw(txt, pixel[i] , tnt);

            }
            spriteBatch.DrawString(textfont, $"rads:{Angle}", new Vector2(200, 400),tnt);
        }
            
    }
}
