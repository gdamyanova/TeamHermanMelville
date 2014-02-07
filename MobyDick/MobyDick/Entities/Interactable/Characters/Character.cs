using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MobyDick.Entities.Interactable.Characters
{
    class Character<TCharacter> : AnimatedEntity<TCharacter> where TCharacter : ICharacter
    {
        protected int Health { get; set; }
        private int Velocity { get; set; }
        protected int Level { get; private set; }
        protected int Experience { get; private set; }
        public Character(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, position, color, spriteBatch)
        {
            this.Health = health;
            this.Velocity = velocity;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.Effect = SpriteEffects.None;
                this.AnimateMovement(gameTime);
                this.Move(Directions.Right);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                //this.Effect = SpriteEffects.FlipHorizontally;
                this.AnimateMovement(gameTime);
                this.Move(Directions.Left);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.AnimateMovement(gameTime);
                this.Move(Directions.Up);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.AnimateMovement(gameTime);
                this.Move(Directions.Down);
            }
        }

        private void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    this.currentDirection = Directions.Up;
                    this.Position -= new Vector2(0, this.Velocity);
                    break;
                case Directions.Down:
                    this.currentDirection = Directions.Down;
                    this.Position += new Vector2(0, this.Velocity);
                    break;
                case Directions.Left:
                    this.currentDirection = Directions.Left;
                    this.Position -= new Vector2(this.Velocity, 0);
                    break;
                case Directions.Right:
                    this.currentDirection = Directions.Right;
                    this.Position += new Vector2(this.Velocity, 0);
                    break;
                default:
                    break;
            }
        }
        public override void Draw() {
            base.Draw();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        private void LevelUp()
        {
            this.Level++;
            this.Experience = 0;
        }
    }
}
