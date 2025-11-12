using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public static class SpriteSheetManager
    {
        public static int spriteSize = 16;

        public static Rectangle[] PacmanFrames = new Rectangle[]
        {
            new Rectangle(0 * spriteSize, 0, spriteSize, spriteSize),
            new Rectangle(1 * spriteSize, 0, spriteSize, spriteSize),
            new Rectangle(2 * spriteSize, 0, spriteSize, spriteSize)
        };

        public static Rectangle[] GhostFrames = new Rectangle[]
        {
            new Rectangle(0 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(1 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(2 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(3 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(4 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(5 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(6 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
            new Rectangle(7 * spriteSize, 1 * spriteSize, spriteSize, spriteSize),
        };

        public static Rectangle Food = new Rectangle(0, 0, spriteSize, spriteSize);
    }
}
