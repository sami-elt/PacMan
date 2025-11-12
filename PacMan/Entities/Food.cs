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
    public class Food : GameObject
    {

        public bool IsEaten { get; set; }

        public Vector2 Position { get { return position; }}


        public Food(Vector2 position, Texture2D texture) : base (texture,position)
        {
            IsEaten = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsEaten)
            {
                float scale = (float)Tilemap.TileSize / 16 * 1f;
                Vector2 center = position + new Vector2(Tilemap.TileSize / 2);
                Vector2 origin = new Vector2(8, 8);

                spriteBatch.Draw(
                    texture,
                    center,
                    SpriteSheetManager.Food,
                    Color.Red,
                    0f,
                    origin,
                    scale,
                    SpriteEffects.None,
                    0f);
            }
        }
    }
}
