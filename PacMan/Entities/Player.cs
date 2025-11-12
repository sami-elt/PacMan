using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PacMan.Map;

namespace PacMan.Entities
{
    public class Player : MovingGameObject
    {
        private KeyboardState keyboardState;

        private float rotation;

        public Player(Vector2 position, Texture2D texture, Tilemap tilemap ) : base(position, texture, tilemap)
        {

        }

        public override int NextDirectionInput()
        {

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                return 0;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                return 1;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                return 2;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }

        public override void Update(GameTime gameTime)
        {

            if (direction.X > 0)
                rotation = MathHelper.ToRadians(0);
            else if (direction.X < 0) 
                rotation = MathHelper.ToRadians(180);
            else if (direction.Y < 0)
                rotation = MathHelper.ToRadians(-90);
            else if (direction.Y > 0)
                rotation = MathHelper.ToRadians(90);

            base.Update(gameTime);

            timeSinceLastFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceLastFrame >= millisecondsPerFrame)
            {
                frameIndex++;
                if (frameIndex >= SpriteSheetManager.PacmanFrames.Length)
                    frameIndex = 0;
                timeSinceLastFrame = 0;
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            float scale = Tilemap.TileSize / 24f;
            Vector2 centerPos = position + new Vector2(Tilemap.TileSize / 2);
            Vector2 origin = new Vector2(8, 8);

            spriteBatch.Draw(
                texture,
                centerPos,
                SpriteSheetManager.PacmanFrames[frameIndex],
                Color.White,
                rotation,
                origin,
                scale,
                SpriteEffects.None,
                0f);
        }
    }
}
