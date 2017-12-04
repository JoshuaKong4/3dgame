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
    class player
    {
        Vector2 pos;
        Vector2 speed;
        private float angle;
        Texture2D Pixel;
        public Rectangle hitbox;
        List<Rectangle> line;
        List<smthng> laser;
        Keys rotateleft;
       Keys rotateright;
        Keys moveforward;
            Keys reverse;
        Keys moveleft;
        Keys moveright;
        int fov ;
        Vector2 velocity;
        bool hitting = false;  
        bool bounceX = false;
        int screenposition;
        Vector2 lateral;
        Viewport v;
        int hitpoint;
        public Vector2 generaldirection;
        Vector2 facingPoint;
        public Vector2 ofcoarse;
        Vector2 perpendicular;
        Vector2 orbit;
  
        
        public Rectangle Hitbox
        {
            get { return new Rectangle((int)pos.X, (int)pos.Y, 10, 10); }
        }

      
        

        public player (Texture2D pixel, Viewport viewport, int screen, Keys left, Keys right, Keys forward, Keys back, Keys side, Keys otherside)
        {
            rotateleft = left;
            rotateright = right;
            moveforward = forward;
            reverse = back;
            moveleft = side;
            moveright = otherside;
            screenposition = screen;
            line = new List<Rectangle>();
            pos = new Vector2(3000, 3000);
          
            laser = new List<smthng>();
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);
            v = viewport;
            
        }
        public void update( map M)
        {

            if( velocity.X >0 )
            {
                generaldirection.X = 1;

            }
            else
            {

                generaldirection.X = -1;
            }
            if (velocity.Y > 0)
            {
                generaldirection.Y = 1;

            }
            else
            {

                generaldirection.Y = -1;
            }

            hitpoint = 0;
            facingPoint = new Vector2((float)Math.Cos(angle), -(float)Math.Sin(angle));
            lateral  = new Vector2((float)Math.Sin(-angle), -(float)Math.Cos(-angle));
            hitbox.X =(int) pos.X;
            hitbox.Y = (int)pos.Y;
            perpendicular = new Vector2((float)Math.Sin(-angle), -(float)Math.Cos(-angle));
            orbit = new Vector2(pos.X +(facingPoint.X*400), pos.Y+(facingPoint.Y*400) );
           ofcoarse = new Vector2((float)(Math.Floor(pos.X /400) ), (float)(Math.Floor(pos.Y / 400)));
            line.Clear();
            laser.Clear();
           
            fov = v.Width;

            for (int i = 0; i < 560; i++)
            {
                int repeat = i - 560 / 2;
                laser.Add(new smthng(new Vector2((int)(perpendicular.X * repeat) + (int)orbit.X, (int)(perpendicular.Y * repeat) + (int)orbit.Y), pos, i + screenposition));
                line.Add(new Rectangle((int)(perpendicular.X * repeat) + (int)orbit.X, (int)(perpendicular.Y * repeat) + (int)orbit.Y, 40, 40));
               
                // laser.Add(new smthng(new Vector2(10,10)));
            }
            KeyboardState ks = Keyboard.GetState();
           
            for (int i = 0; i<M.thng.Count; i++)
            {
                if (M.thng[i].Intersects(hitbox))
                {

                    hitpoint++;
                    
                }
             
            }
            if (hitpoint == 0)
            {
                pos += velocity;
                bounceX = false;

            }
            else
            {
                if (bounceX == false)
                {
                    pos = new Vector2(3000, 3000);
                    velocity = new Vector2(0, 0);
                    angle = 0;
                }
       
                bounceX = true;
                
            }
           // hitpoint = 0;
           // pos.Y += velocity.Y;
           // for (int i = 0; i < M.thng.Count; i++)
           // {
           //     if (M.thng[i].Intersects(hitbox))
           //     {

           //         hitpoint++;

           //     }
           // }


           // if (hitpoint == 0)
           // {
           //     bounceY = false;
               
           // }

           //else
           // {
           //     if (bounceY == true)
           //     {
           //         velocity.Y = -velocity.Y;
           //     }
           //     bounceY = true;
           // }
      
           
            if (velocity.X > 75)
            {
                velocity.X = 74;

            }
            if (velocity.Y > 75)
            {
                velocity.Y = 74;

            }
            if (velocity.X < -75)
            {
                velocity.X = -74;

            }
            if (velocity.Y < -75)
            {
                velocity.Y = -74;

            }
         ///   velocity += facingPoint * 2;
            if (ks.IsKeyDown(moveforward))
            {
                // velocity += facingPoint * 5;
                pos+= facingPoint * 100;
            }
            if (ks.IsKeyDown(moveleft))
            {
                // velocity -= lateral * 10;
                pos -= lateral * 100;
            }
            if (ks.IsKeyDown(reverse))
            {

                // velocity-= facingPoint* 10;
                pos -= facingPoint * 100;

            }
            if (ks.IsKeyDown(moveright))
            {
                // velocity += lateral* 20;
                pos+= lateral * 100;
            }
         
            if (ks.IsKeyDown(rotateleft))
            {
               angle -= 0.05f;
           

            }
            if (ks.IsKeyDown(rotateright))
            {
                angle += 0.05f;               
            }
         



            //for (int i = 0; i < 50; i++)
            //{


            //    line.Add(new Rectangle((int)((facingPoint.X * i) + (int)pos.X) / 4, (int)((facingPoint.Y * i) + (int)pos.Y) / 4, 1, 1));
            //    line.Add(new Rectangle((int)ofcoarse.X / 4, (int)ofcoarse.Y / 4, 5, 5));

            //}


            for (int i = 0; i < 25; i++)
            {
                
                
                    for (int j = 0; j < laser.Count; j++)
                    {
                        laser[j].nextstep(M);
                   
                    }
              


            }
          


        }
        public void temp(SpriteBatch spriteBatch, Color colour, SpriteFont writeing,Color pallet2)
        {

           // spriteBatch.Draw(Pixel, Hitbox, colour);
            //for (int i = 0; i < line.Count; i++)
            //{
            //    spriteBatch.Draw(Pixel, line[i], colour);
            //}
            for (int i = 0; i < laser.Count; i++)
            {
                laser[i].tempdraw(spriteBatch,  Pixel, writeing, pallet2,colour);
            }
            spriteBatch.DrawString(writeing, $" , {generaldirection} ,{velocity} ", new Vector2(0,100), colour);
          // spriteBatch.DrawString(writeing, $"position: {ofcoarse.X/20},{ofcoarse.Y/20} ", pos+new Vector2 (0,100), colour);

        }




        }
}
