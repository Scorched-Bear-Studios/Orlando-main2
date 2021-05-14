using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Orlando
{
    public class Sprite:Component
    {
        protected float _layer { get; set; }

        protected Vector2 velocity;

        protected Vector2 _origin { get; set; }

        protected Vector2 _position { get; set; }

        protected float _rotation { get; set; }

        protected Texture2D _texture;

        protected float Range;

        protected float KillRange;

        public bool isDead = false;

        public Color Colour { get; set; }

  
        public Sprite FollowTarget { get; set; }

   
        public float FollowDistance { get; set; }

        public bool IsRemoved { get; set; }

        public Vector2 Direction;

        public float RotationVelocity = 3f;

        public float LinearVelocity = 4f;

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }

        public Vector2 Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
            }
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = 0;
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;

            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            Colour = Color.White;
        }

        public override void update(GameTime gameTime)
        {
            Follow();
        }

        protected void Follow()
        {
            if (FollowTarget == null)
                return;

            Range = 300f;
            KillRange = 10f;

            var distance = FollowTarget.Position - this.Position;
            _rotation = (float)Math.Atan2(distance.Y, distance.X);

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            var currentDistance = Vector2.Distance(this.Position, FollowTarget.Position);
            if (currentDistance < Range)
            {
                var t = MathHelper.Min((float)Math.Abs(currentDistance - FollowDistance), LinearVelocity);
                velocity = Direction * t;

                Position += velocity;
            }

            float HowFar = Vector2.Distance(this.Position, FollowTarget.Position);

            if (currentDistance<15)
            {
                this.isDead = true;
            }


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Colour, 0, Origin, 1f, SpriteEffects.None, Layer);
        }


        public Sprite SetFollowTarget(Sprite followTarget, float followDistance)
        {
            FollowTarget = followTarget;

            FollowDistance = followDistance;

            return this;
        }



        #region Collision
        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this.velocity.X > FollowTarget.Rectangle.Left &&
              this.Rectangle.Left < FollowTarget.Rectangle.Left &&
              this.Rectangle.Bottom > FollowTarget.Rectangle.Top &&
              this.Rectangle.Top < FollowTarget.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.velocity.X < FollowTarget.Rectangle.Right &&
              this.Rectangle.Right > FollowTarget.Rectangle.Right &&
              this.Rectangle.Bottom > FollowTarget.Rectangle.Top &&
              this.Rectangle.Top < FollowTarget.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.velocity.Y > FollowTarget.Rectangle.Top &&
              this.Rectangle.Top < FollowTarget.Rectangle.Top &&
              this.Rectangle.Right > FollowTarget.Rectangle.Left &&
              this.Rectangle.Left < FollowTarget.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.velocity.Y < FollowTarget.Rectangle.Bottom &&
              this.Rectangle.Bottom > FollowTarget.Rectangle.Bottom &&
              this.Rectangle.Right > FollowTarget.Rectangle.Left &&
              this.Rectangle.Left < FollowTarget.Rectangle.Right;
        }
        #endregion
    }
}
