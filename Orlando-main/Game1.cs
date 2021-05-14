using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Orlando;

// using Comora;

namespace Orlando
    {
        enum Dir
        {
            Up,
            Down,
            Left,
            Right

        }
        public class Game1 : Game
        {
            private GraphicsDeviceManager graphics;
            private SpriteBatch spriteBatch;
            //private Camera camera;
           // Player player;
            //Enemy enemy;
         


            Texture2D orlandoSprite;
            Texture2D orlandoWalkD; //down
            Texture2D orlandoWalkU; //up
            Texture2D orlandoWalkR; //right
            Texture2D orlandoWalkL; //left
            public Texture2D arrow;
            Texture2D levelone;

            private List<Sprite> _sprites;





        public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;

                
            }

            protected override void Initialize()
            {
                //player = new Player();
            
            
                graphics.PreferredBackBufferWidth = 1280;
                graphics.PreferredBackBufferHeight = 960;
               // this.camera = new Camera(graphics.GraphicsDevice);
                graphics.ApplyChanges();


                base.Initialize();
            }

            protected override void LoadContent()
            {

            


            var texture = Content.Load<Texture2D>("Player/orlando");

            var player = new Player(texture)
            {
                //Colour = Color.Green,
                Position = new Vector2(100, 100),
            };

            var texture2 = Content.Load<Texture2D>("Enemy/Skeleton");


            _sprites = new List<Sprite>()
            {


               player,
               new Sprite(texture2)
              {
              Colour = Color.Blue,
              Position = new Vector2(200, 800),
               }.SetFollowTarget(player, 10f),
              


                new Sprite(texture2)
               {
               Colour = Color.Orange,
               Position = new Vector2(400, 800),
               FollowTarget = player,
               FollowDistance = 10f,
                },



                new Sprite(texture2)
               {
               Colour = Color.Red,
               Position = new Vector2(800, 800),
               FollowTarget = player,
               FollowDistance = 10f,
                }






      };

            spriteBatch = new SpriteBatch(GraphicsDevice);


                orlandoSprite = Content.Load<Texture2D>("Player/orlando");
                orlandoWalkD = Content.Load<Texture2D>("Player/owalkd");
                orlandoWalkU = Content.Load<Texture2D>("Player/owalku");
                orlandoWalkR = Content.Load<Texture2D>("Player/owalkr");
                orlandoWalkL = Content.Load<Texture2D>("Player/owalkl");
                arrow = Content.Load<Texture2D>("Player/arrow2");
            levelone = Content.Load<Texture2D>("Assets/levelone");
                //enemy = new Enemy(Content.Load<Texture2D>("Enemy/skeleton"), new Vector2(400, 400), 150);
                // arrow = new Arrow(Content.Load<Texture2D>("Player/arrow2"));
            

                //player.animations[0] = new SpriteAnimation(orlandoWalkL, 4, 10);
               // player.animations[1] = new SpriteAnimation(orlandoWalkR, 4, 10);
               // player.animations[2] = new SpriteAnimation(orlandoWalkD, 4, 10);
               // player.animations[3] = new SpriteAnimation(orlandoWalkU, 4, 10);


              //  player.anim = player.animations[0];

            }

            protected override void Update(GameTime gameTime)
            { 
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

            //player.Update(gameTime);
            //enemy.Update(player, gameTime);
            foreach (var sprite in _sprites)
                sprite.update(gameTime);


            for (int i = 0; i < _sprites.Count; i++)
            {
                var sprite = _sprites[i];

                if (sprite.isDead)
                {
                    //here is where you can reduce the health
                    _sprites.RemoveAt(i);
                    i--;
                }
            }

            //this.camera.Position = player.new;
            //------------> this is the line of code that does not work
            //this.camera.Update(gameTime);



            foreach (Arrow arr in Arrow.arrows) // list contaninig all arrow objects
                {
                    arr.Update(gameTime);


                }

            
            base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);


                spriteBatch.Begin();

              spriteBatch.Draw(levelone, new Vector2(0,0), Color.White);
            // draw arrow
            foreach (Arrow arr in Arrow.arrows)
                {
                  // arrow.Draw(spriteBatch);

                   spriteBatch.Draw(arrow, new Vector2(arr.Position.X - 50, arr.Position.Y - 50), null, Color.White);
                }
            foreach (var sprite in _sprites)
                sprite.Draw(gameTime, spriteBatch);
            //player.anim.Draw(spriteBatch);
            //enemy.Draw(spriteBatch);


            spriteBatch.End();


                base.Draw(gameTime);
            }
        }
    }

       
