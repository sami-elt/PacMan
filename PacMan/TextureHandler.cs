using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public static class TextureHandler
    {


        public static Texture2D spritesheetTexture;
        public static Texture2D floorTexture;
        public static Texture2D wallTexture;
        public static Texture2D foodTexture;

        public static SpriteFont font;

        public static void LoadContent(ContentManager content)
        {
 

            spritesheetTexture = content.Load<Texture2D>("SpriteSheet");
            floorTexture = content.Load<Texture2D>("floortile");
            wallTexture = content.Load<Texture2D>("walltile");
            foodTexture = content.Load<Texture2D>("pacman_pellets");
            font = content.Load<SpriteFont>("font");
        }


    }
}
