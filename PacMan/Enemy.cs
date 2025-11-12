using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Enemy : MovingGameObject
    {

        private Random random;

        public Enemy(Vector2 position, Texture2D texture, Tilemap tilemap) : base(position, texture, tilemap)
        {
            random = new Random();

        }

        public override int NextDirectionInput()
        {
            int randomDirection = random.Next(0, 4);
            return randomDirection;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeSinceLastFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceLastFrame >= millisecondsPerFrame)
            {
                frameIndex++;
                if (frameIndex >= SpriteSheetManager.GhostFrames.Length)
                    frameIndex = 0;
                timeSinceLastFrame = 0;
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            float scale = (float)Tilemap.TileSize / 24f;
            Vector2 centerPos = position + new Vector2(Tilemap.TileSize / 2);
            Vector2 origin = new Vector2(8, 8);

            spriteBatch.Draw(
                texture,
                centerPos,
                SpriteSheetManager.GhostFrames[frameIndex],
                Color.White,
                0f,
                origin,
                scale,
                SpriteEffects.None,
                0f);
        }
    }
}
