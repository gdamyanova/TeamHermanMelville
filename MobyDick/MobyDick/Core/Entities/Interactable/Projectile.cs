using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MobyDick.Core.Entities.Interactable
{
    class Projectile : AnimatedEntity
    {
        private int Velocity;
        public Projectile(Texture2D projectile, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch, Directions direction)
            : base(projectile, form, position, color, spriteBatch)
        {
            this.currentDirection = direction;
            this.Velocity = 5;
        }

        public override void Update()
        {
            this.Move(this.currentDirection);
            base.Update();
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
    }
}
