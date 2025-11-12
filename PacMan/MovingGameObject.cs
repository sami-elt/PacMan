using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public abstract class MovingGameObject : GameObject
    {

        protected Rectangle rec;

        protected Vector2 direction;
        protected float speed;


        protected bool moving;
        protected Vector2 destination;


        protected Tilemap tilemap;

        protected int frameIndex = 0;
        protected double timeSinceLastFrame = 0;
        protected double millisecondsPerFrame = 200;


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
            rec = new Rectangle((int)position.X, (int)position.Y, Tilemap.TileSize, Tilemap.TileSize);
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
