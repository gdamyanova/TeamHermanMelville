namespace MobyDick.Core.Entities.Interactable.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using MobyDick.Core.Entities.Interactable;
    using MobyDick.Core.Entities.Interactable.Items;
    using System.Collections.Generic;

    internal abstract class Character : AnimatedEntity, ICharacter
    {
        public override event EventHandler MoveEvent;
        public override bool HandleCollision(bool MoveAllowed)
        {
            return this.CanMove = MoveAllowed;
        }

        public void UseItem(object item)
        {
            var entity = item as BaseItem;
            entity.Use(this);
        }

        #region Properties
        public int Health { get; private set; }
        public int Velocity { get; private set; }
        protected bool CanMove;
        public ProjectileType CurrentWeapon { get; set; }
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
        public override void Update(GameTime gameTime)
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
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.Attack();
            }
        }

        protected virtual void Move(Directions direction)
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

        public void Attack()
        {
            World world = World.MakeWorld();
            Texture2D projectile;
            switch (this.CurrentWeapon)
            {
                case ProjectileType.StringBuilder:
                    projectile = world.Content.Load<Texture2D>("list-style-type-active");
                    break;
                case ProjectileType.RegularExpression:
                    //break;
                case ProjectileType.LINQ:
                    //break;
                case ProjectileType.Lambda:
                    //break;
                case ProjectileType.Event:
                    //break;
                case ProjectileType.VirtualMethod:
                    //break;
                case ProjectileType.AbstractClass:
                    //break;
                case ProjectileType.Interface:
                    //break;
                case ProjectileType.IEnumerable:
                    //break;
                case ProjectileType.Inheritance:
                    //break;
                case ProjectileType.Polymorphism:
                    //break;
                default:
                    projectile = world.Content.Load<Texture2D>("list-style-type-active");
                    break;
            }
            Vector2 position;
            switch (this.currentDirection)
            {
                case Directions.Down:
                    position = new Vector2(this.Position.X, this.Position.Y + 16);
                    break;
                case Directions.Left:
                    position = new Vector2(this.Position.X - 16, this.Position.Y);
                    break;
                case Directions.Right:
                    position = new Vector2(this.Position.X + 16, this.Position.Y);
                    break;
                case Directions.Up:
                    position = new Vector2(this.Position.X, this.Position.Y - 16);
                    break;
                default:
                    position = new Vector2(this.Position.X, this.Position.Y - 16);
                    break;
            }
            var proj = new Projectile(projectile, new Rectangle(0, 0, 16, 16), position, Color.Wheat, world.spriteBatch, this.currentDirection);
            world.CurrentScene.AddMovingEntity(proj);
        }
        #endregion

    }
}