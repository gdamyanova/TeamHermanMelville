namespace MobyDick.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    internal abstract class BaseEntity<TEntity>
    {

        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Rectangle Form { get; set; }
        public SoundEffect Sound { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle BoundingBox { get; private set; }
        public BaseEntity()
        {

        }
        public BaseEntity(Texture2D texture, Rectangle form, Vector2 position, Color color)
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.Texture, this.Position, this.Form, this.Color);
            spriteBatch.End();
        }

        public virtual void Update()
        {
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Form.Width, this.Form.Height);
        }

        public void PlaySound(float volume = 0.5f)
        {
            this.Sound.Play(volume, 0.5f, 0.5f);
        }

    }
}
