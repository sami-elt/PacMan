using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Tileset : GameObject
    {


        public bool Wall {  get; set; }

        public Tileset(Vector2 position, Texture2D texture, bool wall) : base( texture, position)
        {
     
            this.Wall = wall;
        }
    }
}
