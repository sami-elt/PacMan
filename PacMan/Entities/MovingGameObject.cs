using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacMan.Map;
using System;


namespace PacMan.Entities
{
    public abstract class MovingGameObject : GameObject
    {

        protected Rectangle rec;

        protected Vector2 direction;
        protected float speed;


        protected bool moving;
        protected Vector2 destination;


        protected Tilemap tilemap;

        protected int frames = 0;
        protected double frameTimer = 0;
        protected double frameInterval = 150;


        public Rectangle Rec
        {
            get
            {
                return rec;
            }
        }

        public MovingGameObject(Vector2 position, Texture2D texture, Tilemap tilemap) : base(texture, position)
        {
            this.tilemap = tilemap;
            rec = new Rectangle((int)position.X, (int)position.Y, Tilemap.TileSize / 2, Tilemap.TileSize / 2);
            direction = new Vector2(0, 0);
            speed = 200;
            moving = false;
            destination = Vector2.Zero;

        }

        public abstract int NextDirectionInput();


        public virtual void Update(GameTime gameTime)
        {


            if (!moving)
            {
                if (NextDirectionInput() == 0)
                {
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (NextDirectionInput() == 1)
                {
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (NextDirectionInput() == 2)
                {
                    ChangeDirection(new Vector2(1, 0));
                }
                else if (NextDirectionInput() == 3)
                {
                    ChangeDirection(new Vector2(0, 1));
                }
            }
            else
            {
                position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                rec.X = (int)position.X;
                rec.Y = (int)position.Y;

                if (Vector2.Distance(position, destination) < 1)
                {
                    position = destination;
                    moving = false;
                }
            }

        }

        public void AnimationUpdate(GameTime gameTime, int maxFrames)
        {
            frameTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer >= frameInterval)
            {
                frames++;
                if (frames >= maxFrames)
                    frames = 0;
                frameTimer = 0;
            }
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = position + direction * Tilemap.TileSize;

            if (!tilemap.GetTileAtPosition(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
        }

    }
}
