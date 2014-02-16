namespace MobyDick.Core.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Core.Entities;
    using MobyDick.Core.Entities.Interactable;
    internal abstract class AnimatedEntity : BaseEntity<AnimatedEntity>, IAnimatedEntity
    {
        #region Priperties
        public float Timer { get; set; }
        public float Interval { get; set; }
        public int CurrentFrameNumber { get; set; }
        public int MaxFrames { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public SpriteEffects Effect { get; set; }
        public Directions currentDirection { get; set; }
        public int SpriteRows { get; set; }
        public Rectangle CurrentFrame
        {
            get
            {
                return new Rectangle((this.Texture.Width / this.MaxFrames * this.CurrentFrameNumber),
                    this.Texture.Height / this.SpriteRows * (int)this.currentDirection,
                    this.Form.Width,
                    this.Form.Height);
            }
        }
        #endregion

        #region Constructors
        public AnimatedEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, position, color)
        {
            this.Timer = 0f;
            this.CurrentFrameNumber = 0;
            this.MaxFrames = 3;
            this.Interval = 1000f/10f;
            this.Effect = SpriteEffects.None;
            this.spriteBatch = spriteBatch;
            this.SpriteRows = 4;
        }
        public AnimatedEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch, 
            int currentFrame, int maxFrames, int spriteRows,float interval = 1000f/10f)
            : base(texture, form, position, color)
        {
            this.Timer = 0f;
            this.CurrentFrameNumber = currentFrame;
            this.MaxFrames = maxFrames;
            this.Interval = interval;
            this.spriteBatch = spriteBatch;
            this.Effect = SpriteEffects.None;
            this.SpriteRows = spriteRows;
        }
        #endregion

        #region Methods
        protected void AnimateMovement(GameTime gameTime)
        {
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer > this.Interval)
            {
                this.CurrentFrameNumber++;
                this.CurrentFrameNumber = this.CurrentFrameNumber % this.MaxFrames;
                this.Timer = 0f;
            }
            this.Update();
        }

        public override void Update()
        {
            base.Update();
        }
        public virtual void Draw()
        {
            if (this.Enabled)
            {
                this.spriteBatch.Begin();
                this.spriteBatch.Draw(this.Texture, this.Position, this.CurrentFrame, this.Color, 0, new Vector2(0, 0), 1, this.Effect, 0);
                this.spriteBatch.End();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
