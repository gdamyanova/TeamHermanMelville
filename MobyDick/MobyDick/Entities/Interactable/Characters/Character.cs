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
    class Character<TCharacter> : BaseEntity<TCharacter> where TCharacter : ICharacter
    {
        private int Health { get; set; }
        int Velocity { get; set; }

        public Character(Texture2D texture, Rectangle form, int health, Vector2 position, Color color)
            : base(texture, form, position, color)
        {
            this.Health = health;
            this.Velocity = 10;
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.Move(Directions.Right);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.Move(Directions.Left);   
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.Move(Directions.Up);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.Move(Directions.Down);
            }
        }

        private void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    this.Position -= new Vector2(0, this.Velocity);
                    break;
                case Directions.Down:
                    this.Position += new Vector2(0, this.Velocity);
                    break;
                case Directions.Left:
                    this.Position -= new Vector2(this.Velocity, 0);
                    break;
                case Directions.Right:
                    this.Position += new Vector2(this.Velocity, 0);
                    break;
                default:
                    break;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
