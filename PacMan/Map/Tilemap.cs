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

        private Player player;
        private Enemy enemy;

        private List<Food> food = new List<Food>();

        public List<Food> Food
        {
            get { return food; }
        }


        public Player Player
        {
            get { return player; }
        }

        public Enemy Enemy
        {
            get { return enemy; }
        }
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
                    Vector2 pos = new Vector2(j * TileSize, i * TileSize);

                    if (level[i][j] == 'w')
                    {
                        Tileset tile = new Tileset(pos, TextureHandler.wallTexture, true);
                        tileArray[j, i] = tile;
                    }
                    else
                    {
                        Tileset tile = new Tileset(pos, TextureHandler.floorTexture, false);
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

                    if (level[i][j] == '-')
                    {
                        food.Add(new Food(pos, TextureHandler.foodTexture));
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
