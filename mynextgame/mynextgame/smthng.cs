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

    class smthng : draw
    {

        float referenceangle;
        public bool xchosen;
        Vector2 aim;
        Vector2 aimdirection;
        Vector2 initial;
        int size = 400;
        Vector2 hitpos;
        Vector2 shift;
        map mapp;
        Vector2 samedifference;
        public Vector2 nextfactor;
        float dist;
        public bool detected ;
        Vector2 skipstep;
        Vector2 position;
        Vector2 delta;
        Vector2 difference;
        Vector2 coarse;
        int id;

        public smthng(Vector2 Position, Vector2 referto, int ID)

        {
            id = ID;
    
       
            aimdirection = new Vector2(0, 0);
            nextfactor = new Vector2();
            delta = new Vector2();
           
            position = Position;
            aim = new Vector2(position.X - referto.X, position.Y - referto.Y);
            
            initial = Position;


           





        }
        public void nextstep(map m1)
        {
            mapp = m1;
            if (detected == false)
            {
                if (aim.X < 0)
                {
                    nextfactor.X = (float)Math.Floor((position.X - 1) / size) * size;
                    aimdirection.X = -1;

                }
                if (aim.X > 0)
                {
                    nextfactor.X = (float)Math.Ceiling((position.X + 1) / size) * size;
                    aimdirection.X = 1;
                }

                if (aim.Y < 0)
                {
                    nextfactor.Y = (float)Math.Floor((position.Y - 1) / size) * size;
                    aimdirection.Y = -1;
                }
                if (aim.Y > 0)
                {
                    nextfactor.Y = (float)Math.Ceiling((position.Y + 1) / size) * size;
                    aimdirection.Y = 1;
                }


                shift = new Vector2((float)Math.Abs(nextfactor.X - position.X), (float)Math.Abs(nextfactor.Y - position.Y));

                referenceangle = (float)Math.Abs(Math.Atan2(aim.Y, aim.X));


                delta = new Vector2((float)Math.Sqrt((shift.X * shift.X) + ((Math.Sin(referenceangle) * shift.X / Math.Cos(referenceangle))) * (Math.Sin(referenceangle) * shift.X / Math.Cos(referenceangle))), (float)Math.Sqrt((shift.Y * shift.Y) + ((Math.Cos(referenceangle) * shift.Y / Math.Sin(referenceangle)) * (Math.Cos(referenceangle) * shift.Y / Math.Sin(referenceangle)))));

                if (delta.X < delta.Y)
                {
                    xchosen = true;


                    skipstep = new Vector2(shift.X, (shift.X * (float)Math.Abs(Math.Tan(referenceangle))));


                }
                if (delta.X > delta.Y)
                {
                    xchosen = false;


                    skipstep = new Vector2((shift.Y * (1 / (float)Math.Abs((Math.Tan(referenceangle))))), shift.Y);


                }

                skipstep = skipstep * aimdirection;


                position = position + skipstep;

                coarse = new Vector2((float)Math.Ceiling((position.X + aimdirection.X) / size), (float)Math.Floor((position.Y + aimdirection.Y) / size));




                samedifference = new Vector2((float)Math.Abs(coarse.Y - initial.Y), (float)Math.Abs(coarse.X - initial.X));
                difference = new Vector2((float)Math.Abs(position.Y - initial.Y), (float)Math.Abs(position.X - initial.X));
              






          

                if (coarse.X > 0 && coarse.X < 100 && coarse.Y > 0 && coarse.Y < 100)
                {
                    if (m1.array[(int)coarse.X, (int)coarse.Y] > 0 )
                    
                    {
                        detected = true;

                        
                   
                        if (position.X > coarse.X)
                        {
                            hitpos.X = Math.Abs(position.X - (coarse.X * size));
                        }

                        if (position.X < coarse.X)
                        {
                            hitpos.X = Math.Abs((coarse.X * size) - position.X);


                        }
                        if (position.Y > coarse.Y)
                        {
                            hitpos.Y = position.Y - (coarse.Y * size);
                        }
                        if (position.Y < coarse.Y)
                        {

                            hitpos.Y = (coarse.Y * size) - position.Y;
                        }

                    }

                }
            }












        }





        public void tempdraw(SpriteBatch spriteBatch, Texture2D pixel, SpriteFont fontsprite, Color c2, Color colortint)
        {



            if (detected == true)
            {
                if (mapp.array[(int)coarse.X, (int)coarse.Y] == 7)
                {

                    dist = size * 200 / (float)Math.Sqrt(samedifference.Y * samedifference.Y + samedifference.X * samedifference.X);
                    spriteBatch.Draw(mapp.textures[5], new Rectangle(id , (int)(180 - (dist / 2)), 1, (int)(dist)), c2);

                }
                else
                {
                    dist = size * 200 / (float)Math.Sqrt(difference.Y * difference.Y + difference.X * difference.X);
                    if (xchosen == true)
                    {



                        spriteBatch.Draw(mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1], new Rectangle(id * 1, (int)(180 - (dist / 2)), 1, (int)(dist)), new Rectangle((int)(hitpos.Y), 0, mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Width /size, mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Height), c2);
                       // spriteBatch.Draw(mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1], new Rectangle(id , (int)(180 - (dist / 2)), 1, (int)(dist)), new Rectangle((int)(hitpos.Y) * (mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Width / size), 0, mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Width / size, mapp.textures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Height), c2);
                    }
                    else
                    {


                         spriteBatch.Draw(mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1], new Rectangle(id * 1, (int)(180 - (dist / 2)), 1, (int)(dist)), new Rectangle((int)(hitpos.X), 0, mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Width /size, mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Height), colortint);
                      //  spriteBatch.Draw(mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1], new Rectangle(id , (int)(180 - (dist / 2)), 1, (int)(dist)), new Rectangle((int)(hitpos.X) * (mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Width / size), 0, mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Width / size, mapp.sidetextures[mapp.array[(int)coarse.X, (int)coarse.Y] - 1].Height), colortint);

                    }
                    if (id == 280)
                    {
                        spriteBatch.DrawString(fontsprite, $" samedifference: {samedifference},coarse: {coarse}", new Vector2(0, 150), c2);
                        spriteBatch.DrawString(fontsprite, $"difference:{difference},initial:{initial},distance:{dist}", new Vector2(0, 200), c2);
                    }
                }
                if (id == 280)
                {
                    spriteBatch.DrawString(fontsprite, $"distance:{dist}", new Vector2(0, 250), c2);
                }
            }
          


        }
    }
}
