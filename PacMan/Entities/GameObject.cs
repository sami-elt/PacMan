using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan.Entities
{
    public class GameObject
    {

        protected Texture2D texture;
        protected Vector2 position;
        

        public GameObject(Texture2D texture, Vector2 position) {
            this.texture = texture;
            this.position = position;
        
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
