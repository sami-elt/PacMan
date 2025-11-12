using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacMan.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
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

            AnimationUpdate(gameTime, SpriteSheetManager.GhostFrames.Length);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            float scale = Tilemap.TileSize / 24f;
            Vector2 center = position + new Vector2(Tilemap.TileSize / 2);
            Vector2 origin = new Vector2(8, 8);

            spriteBatch.Draw(
                texture,
                center,
                SpriteSheetManager.GhostFrames[frames],
                Color.White,
                0f,
                origin,
                scale,
                SpriteEffects.None,
                0f);
        }
    }
}
