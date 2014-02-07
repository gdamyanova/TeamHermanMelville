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
    internal class BaseEntity<TEntity> where TEntity : IEntity
    {
        protected Texture2D Texture { get;  set; }
        protected Color Color { get;  set; }
        protected Rectangle Form { get; set; }
        protected SoundEffect Sound { get; set; }
        protected Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        private Vector2 position;
        public BaseEntity(Texture2D texture, Rectangle form, Vector2 position, Color color)
        {
            this.Position = position;
            this.Color = color;
            this.Texture = texture;
            this.Form = form;
        }

        public BaseEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SoundEffect sound)
            : this(texture, form, position, color)
        {
            this.Sound = sound;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.Texture, this.Position, this.Form, this.Color);
            spriteBatch.End();
        }

        public virtual void Update()
        {

        }

        public void PlaySound(float volume = 0.5f)
        {
            this.Sound.Play(volume, 0.5f, 0.5f);
        }
    }
}
