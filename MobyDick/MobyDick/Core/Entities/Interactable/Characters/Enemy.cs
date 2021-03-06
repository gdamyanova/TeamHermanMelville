﻿namespace MobyDick.Core.Entities.Interactable.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Enemy : NPC
    {
        public override event EventHandler MoveEvent;
        public Enemy(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, health, velocity, position, color, spriteBatch)
        {

        }

        public override void Update()
        {
            this.Move(this.currentDirection);
        }
        protected override void Move(Directions direction)
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
    }
}
