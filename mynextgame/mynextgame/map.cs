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
    class map
    {
       public List<Rectangle> thng;
        int temp;
        int counter;
        int size= 400;
        public List<Texture2D> textures1;
        public List<Texture2D> sidetextures1;
        public List<Texture2D> textures;
        public List<Texture2D> sidetextures;
        Vector2 two = new Vector2(2, 2);
        public int[,] array2 = new int[100, 100];
        public int[,] array = new int [100, 100];
        public map(Texture2D T1, Texture2D T2, Texture2D T3, Texture2D T4, Texture2D T5, Texture2D T6)
        {
            thng = new List<Rectangle>();
            sidetextures = new List<Texture2D>();
            textures = new List<Texture2D>();


            //sidetextures1.Add(T1);
            //sidetextures1.Add(T2);
            //sidetextures1.Add(T3);
            //sidetextures1.Add(T4);
            //sidetextures1.Add(T5);
            //sidetextures1.Add(T6);
            //textures1.Add(T1);
            //textures1.Add(T2);
            //textures1.Add(T3);
            //textures1.Add(T4);
            //textures1.Add(T5);
            //textures1.Add(T6);

            sidetextures.Add(T1);
            sidetextures.Add(T2);
            sidetextures.Add(T3);
            sidetextures.Add(T4);
            sidetextures.Add(T5);
            sidetextures.Add(T6);
            textures.Add(T1);
            textures.Add(T2);
            textures.Add(T3);
            textures.Add(T4);
            textures.Add(T5);
            textures.Add(T6);
            // array[1, 0] = 3;

            array[2, 5] = 7;
            //array[2, 6] = 1;
            //array[3, 5] = 2;
            //array[4, 5] = 2;
            //array[2, 7] = 1;
            //array[3, 7] = 2;
            //array[4, 7] = 1;

            //array[7, 6] = 4;
            //array[7, 7] = 2;
            //array[7, 8] = 2;
            //array[7, 9] = 2;
            //array[7, 10] = 1;
            //array[11, 7] = 2;
            //array[12, 7] = 2;
            //array[13, 7] = 1;
            //array[14, 7] = 2;
            //array[15, 7] = 1;
            for (int i = 0; i < 99; i++)
            {
                array[1, i] = 1;
                array[99, i] = 1;
                array[i, 99] = 1;
                array[i, 1] = 1;

            }
            for (int i = 0; i < 79; i++)
            {
                array[11, i +10] = 1;
                //array[79, i-10] = 1;
                array[i, 79+10] = 1;
                array[i, 11-10] = 1;

            }
            for (int i = 0; i < 8; i++)
            {
              
            }


            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (array[i, j] >0 )
                    {
                        array2[i, j] = array[i, j];
                        thng.Add(new Rectangle((i-1) * size, (j) * size, size, size));
                       
                    }

                }


            }
           
        }
        
        
        public void update (player p1, player p2)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    for (int j = 0; j < 100; j++)
            //    {
            //        if (array[i, j] > 0)
            //        {
            //            thng.Add(new Rectangle((i - 1) * size, (j) * size, size, size));

            //        }

            //    }


            //}
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Space))
            {
                if(p1.ofcoarse.X >0 && p1.ofcoarse.X < 100 && p1. ofcoarse.Y >0 && p1. ofcoarse.Y <100)
                {
               
                    array2[(int)p1.ofcoarse.X , (int)p1.ofcoarse.Y] = 5;
                }

            }
            if (ks.IsKeyDown(Keys.Enter))
            {
                if (p2.ofcoarse.X > 0 && p2.ofcoarse.X < 100 && p2.ofcoarse.Y > 0 && p2.ofcoarse.Y < 100)
                {
               
                    array2[(int)p2.ofcoarse.X, (int)p2.ofcoarse.Y] = 5;
                }
               
            }
          

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if(i == p2.ofcoarse.X && j== p2.ofcoarse.Y )
                    {
                        //array[i, j] = 4;

                    }
                    else
                    {
                        array[i, j] = array2[i,j];

                    }
                    if (i== p1.ofcoarse.X && j == p1.ofcoarse.Y)
                    {

                       // array[i, j] = 4;
                    }
                     else
                   {


                   }
                   
                }


            }


        }
        public void showwalls(SpriteBatch spriteBatch, Color paint, Texture2D txtr)
       
        {
            for (int i = 0; i < thng.Count; i++)
            {
                spriteBatch.Draw(txtr, thng[i], paint);
            }
        }
    }
}
