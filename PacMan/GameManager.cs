using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacMan.Entities;
using PacMan.Map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class GameManager
    {

        private Tilemap tilemap;

        private int lives;
        private bool gameOver;
        private bool gameWon;

        private float timer = 0f;
        private float invunarable = 3f;
        private bool isInvunarble = false;

        public bool GameOver { get { return gameOver; }}
        public bool GameWon { get { return gameWon; }}

        
        public GameManager(Tilemap tilemap)
        {
            this.tilemap = tilemap;
            this.lives = lives = 3;
            this.gameOver = false;
            this.gameWon = false;
        }

        public void Update(GameTime gameTime)
        {

            if (isInvunarble)
            {
                timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer <= 0)
                {
                    isInvunarble = false;
                    Debug.WriteLine("Invulnerability ended");
                }
            }

            FoodCollision();
            EnemyCollision();
            WinCondition();
        }

        private void FoodCollision()
        {
            Rectangle playerRectangle = tilemap.player.Rec;

            foreach(Food food in tilemap.food)
            {
                if (!food.IsEaten)
                {
                    Rectangle foodRectangle = new Rectangle(
                        (int)food.Position.X,
                        (int)food.Position.Y,
                        Tilemap.TileSize / 2,
                        Tilemap.TileSize / 2
                        );

                    if(playerRectangle.Intersects(foodRectangle))
                    {
                        food.IsEaten = true;
                    }
                }
            }
        }

        private void EnemyCollision()
        {
            Rectangle playerRectangle = tilemap.player.Rec;
            Rectangle enemeyRectrange = tilemap.enemy.Rec;

            if(playerRectangle.Intersects(enemeyRectrange))
            {

                if(!isInvunarble)
                {
                    lives--;
                    isInvunarble = true;

                    timer = invunarable;

                    Debug.WriteLine("collide " + lives);
                }

                if (lives <= 0)
                {
                    gameOver = true;
                }
            }
        }

        private void WinCondition()
        {
            bool allFoodIsEaten = true;

            foreach (Food food in tilemap.food)
            {
                if (!food.IsEaten)
                {
                    allFoodIsEaten = false;
                    break;
                }
            }
            if (allFoodIsEaten) 
            {
                gameWon = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(GameOver)
            {
                string gameOverText = "GAME OVER";

                Vector2 textPosition = new Vector2(
                GraphicsDeviceManager.DefaultBackBufferWidth / 2,
                GraphicsDeviceManager.DefaultBackBufferHeight / 2);

                spriteBatch.DrawString(TextureHandler.font, gameOverText, textPosition, Color.Red);
            }

            if (GameWon)
            {
                string winningText = "YOU WIN!!!";

                Vector2 textPosition = new Vector2(
                GraphicsDeviceManager.DefaultBackBufferWidth / 2,
                GraphicsDeviceManager.DefaultBackBufferHeight / 2);

                spriteBatch.DrawString(TextureHandler.font, winningText, textPosition, Color.Green);
            }

        }
    }
}
