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
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        draw draw;
        player p1;
        player p2;
        smthng test;
        Color color = Color.Black;
        Color color2 = Color.Gray;
        Color c3 = Color.White;
        Color c4 = Color.DarkGreen;
        Color sky = Color.White;
        GraphicsDeviceManager graphics;
        Rectangle gnd;
        SpriteBatch spriteBatch;
        test experiment;
        Texture2D texture1;
        Texture2D texture2;
        Texture2D texture3;
        Texture2D texture4;
        Texture2D texture5;
        Texture2D textureblank;
        Rectangle rectangle;
        map level;
        int[] normalArray = new int[3];
        SpriteFont font;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            draw = new draw();
            graphics.PreferredBackBufferHeight = 360;
            graphics.PreferredBackBufferWidth = 1120;
        }

      
        protected override void Initialize()
        {
           

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            experiment = new test();
            test = new smthng(new Vector2(100,100), new Vector2(0,0), 1);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SpriteFont1");
            gnd = new Rectangle(0, 180, 1800, 5700);
            texture1 = Content.Load<Texture2D>("51114");
            texture2 = Content.Load<Texture2D>("square");
            texture3 = Content.Load<Texture2D>("mint");
            rectangle = new Rectangle(360, 160, 200, 200);
            texture4 = Content.Load<Texture2D>("square");
            texture5 = Content.Load<Texture2D>("mint");
            textureblank = Content.Load<Texture2D>("pixel");
            p1 = new player(texture1, GraphicsDevice.Viewport, 0, Keys.Q, Keys.E, Keys.W, Keys.S, Keys.A, Keys.D);
            p2 = new player(texture1, GraphicsDevice.Viewport, 560, Keys.U, Keys.O, Keys.I, Keys.K, Keys.J, Keys.L);
            level = new map(texture1,texture2,  texture3, texture4, texture5,textureblank);
          
           
        }

       
        protected override void UnloadContent()
        {
           
        }

       
        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
           level.update(p1,p2);

            experiment.update();
            p1.update(level);
            p2.update(level);
           
            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(textureblank, gnd, c4);

            draw.sketch(spriteBatch, texture1, color, font);
           // experiment.write(spriteBatch, font);
           
            //level.showwalls(spriteBatch, color, texture1);
            p1.temp(spriteBatch, color2, font, c3);
            p2.temp(spriteBatch, color2, font, c3);
            spriteBatch.Draw(textureblank, new Rectangle(560, 0, 1, 1000), color2);
         //   spriteBatch.Draw(textureblank, new Rectangle(0, 180, 1000, 1), color2);
           // spriteBatch.Draw(texture5,rectangle, color2);
            spriteBatch.End();
            base.Draw(gameTime);



        }
    }
}
