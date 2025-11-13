using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacMan.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Map
{
    public class Tilemap
    {

        private Tileset[,] tileArray;
        public static int TileSize { get; } = 50;

        public Player player;
        public Enemy enemy;

        public List<Food> food = new List<Food>();

        public List<string> ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            List<string> result = new List<string>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                result.Add(line);
            }
            sr.Close();
            return result;
        }

        public void CreateLevel(string fileName)
        {
            List<string> level = ReadFromFile(fileName);

            tileArray = new Tileset[level[0].Length, level.Count];

            for (int i = 0; i < level.Count; i++)
            {
                for (int j = 0; j < level[0].Length; j++)
                {

                    if (level[i][j] == 'w')
                    {
                        Tileset tile = new Tileset(new Vector2(j * TileSize, i * TileSize), TextureHandler.wallTexture, true);
                        tileArray[j, i] = tile;
                    }
                    else
                    {
                        Tileset tile = new Tileset(new Vector2(j * TileSize, i * TileSize), TextureHandler.floorTexture, false);
                        tileArray[j, i] = tile;


                    }

                    if (level[i][j] == 'p')
                    {
                        player = new Player(new Vector2(j * TileSize, i * TileSize), TextureHandler.spritesheetTexture, this);
                    }

                    if (level[i][j] == 'e')
                    {
                        enemy = new Enemy(new Vector2(j * TileSize, i * TileSize), TextureHandler.spritesheetTexture, this);
                    }

                    if (level[i][j] == '-' || level[i][j] == 'e')
                    {
                        food.Add(new Food(new Vector2(j * TileSize, i * TileSize), TextureHandler.foodTexture));
                    }
                }
            }
        }

        public bool GetTileAtPosition(Vector2 position)
        {
            return tileArray[(int)position.X / TileSize, (int)position.Y / TileSize].Wall;

        }

        public void Draw(SpriteBatch spriteBatch)
        {


            for (int i = 0; i < tileArray.GetLength(1); i++)
            {
                for (int j = 0; j < tileArray.GetLength(0); j++)
                {
                    if (tileArray[j, i] != null)
                    {
                        tileArray[j, i].Draw(spriteBatch);
                    }
                }
            }

            foreach (var f in food)
            {
                f.Draw(spriteBatch);
            }
        }
    }
}
