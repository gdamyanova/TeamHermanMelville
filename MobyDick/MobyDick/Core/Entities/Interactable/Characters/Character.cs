namespace MobyDick.Entities.Interactable.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using MobyDick.Core.Entities.Interactable;
    using MobyDick.Entities.Interactable.Items;
    using System.Collections.Generic;

    internal abstract class Character : AnimatedEntity, ICharacter, IInteractable
    {
        public event EventHandler MoveEvent;
        public bool HandleMoveCollision(bool MoveAllowed)
        {
            return this.CanMove = MoveAllowed;
        }
        #region Properties
        public int Health { get; private set; }
        public int Velocity { get; private set; }
        private bool CanMove;
        #endregion

        #region Constructors
        public Character(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, position, color, spriteBatch)
        {
            this.Health = health;
            this.Velocity = velocity;
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.AnimateMovement(gameTime);
                this.Move(Directions.Right);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
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
            if (this.MoveEvent != null)
            {
                this.MoveEvent.Invoke(this);
            }
            this.currentDirection = direction;
            if (this.CanMove)
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
        public override void Draw()
        {
            base.Draw();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
