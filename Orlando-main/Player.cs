﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orlando.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orlando;


namespace Orlando
{
    public class Player : Sprite
    {
        // protected AnimationManager _animationManager;

        // protected Dictionary<string, Animation> _animations;

        //public Vector2 Velocity;

        private KeyboardState kstateOld = Keyboard.GetState();

        private Dir direction = Dir.Down;
        public Player(Texture2D texture): base(texture)
        {

        }

       /* public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }*/
        public override void update(GameTime gametime)
        {
           // _animationManager.Update(gametime);

             var velocity = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                velocity.Y = -LinearVelocity;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                velocity.Y = LinearVelocity;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                velocity.X = -LinearVelocity;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                velocity.X = LinearVelocity;

           
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Arrow.arrows.Add(new Arrow(_position, direction));

            Position += velocity;
            velocity = Vector2.Zero;

          //  SetAnimations();
          //  _animationManager.Update(gametime);
            
        }

       /* protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }*/
        #region Carolacode
        /* 
         private Vector2 position = new Vector2(500, 300);
         private int speed = 250;
         private Dir direction = Dir.Down;
         private bool isMoving = false;
         private KeyboardState kStateOld = Keyboard.GetState();



         public SpriteAnimation anim;
         public SpriteAnimation[] animations = new SpriteAnimation[4];




        public Vector2 Position
         {
             get
             {
                 return position;

             }
         }



         public void setX(float newX)
         {
             position.X = newX;
         }

         public void setY(float newY)
         {
             position.Y = newY;
         }







         public void Update(GameTime gameTime)
         {
             KeyboardState kState = Keyboard.GetState();
             float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;





             isMoving = false;

             if (kState.IsKeyDown(Keys.Right))
             {
                 direction = Dir.Right;
                 isMoving = true;
             }

             if (kState.IsKeyDown(Keys.Left))
             {
                 direction = Dir.Left;
                 isMoving = true;
             }

             if (kState.IsKeyDown(Keys.Up))
             {
                 direction = Dir.Up;
                 isMoving = true;
             }

             if (kState.IsKeyDown(Keys.Down))
             {
                 direction = Dir.Down;
                 isMoving = true;
             }

             if (isMoving) // check this if player stops moving
             {
                 switch (direction)
                 {
                     case Dir.Right:
                         if (position.X < 1240)
                             position.X += speed * dt;
                         break;
                     case Dir.Left:
                         if (position.X > 100) //this
                             position.X -= speed * dt;
                         break;
                     case Dir.Down:
                         if (position.Y < 900)
                             position.Y += speed * dt;
                         break;
                     case Dir.Up:
                         if (position.Y > 100) // this
                             position.Y -= speed * dt;
                         break;
                 }
             }

             switch (direction)
             {
                 case Dir.Left:
                     anim = animations[0];
                     break;
                 case Dir.Right:
                     anim = animations[1];
                     break;
                 case Dir.Down:
                     anim = animations[2];
                     break;
                 case Dir.Up:
                     anim = animations[3];
                     break;
             }



             anim.Position = new Vector2(position.X - 50, position.Y - 50);

             if (kState.IsKeyDown(Keys.Space))
                 anim.setFrame(0);
             else if (isMoving)
                 anim.Update(gameTime);
             else
                 anim.setFrame(1);

             if (kState.IsKeyDown(Keys.Space) && kStateOld.IsKeyUp(Keys.Space))
                 Arrow.arrows.Add(new Arrow(position, direction));

             kStateOld = kState;

         }*/

        #endregion
    }

}
