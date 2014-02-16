namespace MobyDick.Core.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Core;
    using MobyDick.Core.Entities;
    internal abstract class BaseEntity<TEntity> : DrawableGameComponent, IEntity
    {
        public virtual event EventHandler MoveEvent;
        public virtual bool HandleCollision(bool CanMove)
        {
            return true;
        }
        #region Properties
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Rectangle Form { get; set; }
        public SoundEffect Sound { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; private set; }
        private static Game GameContext;
        #endregion

        #region Constructors
        public BaseEntity(Texture2D texture, Rectangle form, Vector2 position, Color color) : base(GameContext)
        {
            this.Position = position;
            this.Color = color;
            this.Texture = texture;
            this.Form = form;
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Form.Width, this.Form.Height);
        }
        public BaseEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SoundEffect sound)
            : this(texture, form, position, color)
        {
            this.Sound = sound;
        }
        #endregion

        #region Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (this.Enabled)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(this.Texture, this.Position, this.Form, this.Color);
                spriteBatch.End();
            }
        }

        public virtual void Update()
        {
            if (this.Enabled)
            {
                this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Form.Width, this.Form.Height);
            }
        }

        public void PlaySound(float volume = 0.5f)
        {
            this.Sound.Play(volume, 0.5f, 0.5f);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion

        #region Stupid static method, refactor!
        public static void SetGameContext(Game game)
        {
            BaseEntity<IEntity>.GameContext = game;
        }
        #endregion
    }
}
