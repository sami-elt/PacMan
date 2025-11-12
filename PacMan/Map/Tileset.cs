using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacMan.Entities;


namespace PacMan.Map
{
    public class Tileset : GameObject
    {


        public bool Wall {  get; set; }

        public Tileset(Vector2 position, Texture2D texture, bool wall) : base( texture, position)
        {
     
            Wall = wall;
        }
    }
}
