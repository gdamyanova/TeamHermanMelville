using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MobyDick.Entities
{
    class AnimatedEntity<TEntity> : BaseEntity<TEntity> where TEntity : IAnimatedEntity
    {
        protected float Timer { get; set; }
        protected float Interval { get; set; }
        protected int CurrentFrameNumber { get; set; }
        protected int MaxFrames { get; set; }
        protected SpriteBatch spriteBatch { get; set; }
        protected Rectangle CurrentFrame
        {
            get
            {
                return new Rectangle((this.Texture.Width / this.MaxFrames * this.CurrentFrameNumber),
                    this.Form.Y,
                    this.Form.Width,
                    this.Form.Height);
            }
        }
        public AnimatedEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, position, color)
        {
            this.Timer = 0f;
            this.CurrentFrameNumber = 0;
            this.MaxFrames = 16;
            this.Interval = 1000f/10f;
            this.spriteBatch = spriteBatch;
        }
        public AnimatedEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch, int currentFrame, int maxFrames, float interval = 1000f/10f)
            : base(texture, form, position, color)
        {
            this.Timer = 0f;
            this.CurrentFrameNumber = currentFrame;
            this.MaxFrames = maxFrames;
            this.Interval = interval;
            this.spriteBatch = spriteBatch;
        }

        protected void AnimateRight(GameTime gameTime)
        {
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer > this.Interval)
            {
                this.CurrentFrameNumber++;
                this.CurrentFrameNumber = this.CurrentFrameNumber % this.MaxFrames;
                this.Timer = 0f;
            }
            this.Draw();
        }

        protected void AnimateLeft(GameTime gameTime)
        {
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer > this.Interval)
            {
                this.CurrentFrameNumber++;
                this.CurrentFrameNumber = this.CurrentFrameNumber % this.MaxFrames;
                this.Timer = 0f;
            }
            this.Draw();
        }

        public override void Update()
        {
            base.Update();
        }
        public void Draw()
        {
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.Texture, this.Position, this.CurrentFrame, this.Color, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            this.spriteBatch.End();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
