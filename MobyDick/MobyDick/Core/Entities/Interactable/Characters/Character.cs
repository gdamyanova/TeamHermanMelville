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
        public void HandleCollision(object entity)
        {
            if (entity is Character)
            {
                this.HandleCharacterInteraction(entity as Character);
            }
            else if (entity is BaseItem)
            {

            }
            else if (entity == null)
            {

            }
        }
        #region Properties
        public int Health { get; private set; }
        public int Velocity { get; private set; }
        private Vector2 PreviousPosition { get; set; }
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
        private void HandleCharacterInteraction(Character entity)
        {
            switch (this.currentDirection)
            {
                case Directions.Down:
                this.Position = new Vector2(this.Position.X, entity.Position.Y - this.Form.Height);
                    break;
                case Directions.Left:
                    this.Position = new Vector2(entity.Position.X + this.Form.Width, this.Position.Y);
                    break;
                case Directions.Right:
                    this.Position = new Vector2(entity.Position.X - this.Form.Width, this.Position.Y);
                    break;
                case Directions.Up:
                this.Position = new Vector2(this.Position.X, entity.Position.Y + this.Form.Height);
                    break;
                default:
                    break;
            }
        }
        public void Update(GameTime gameTime)
        {
            this.PreviousPosition = this.Position;
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
