using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MobyDick.Entities.Interactable.Characters
{
    class Character<TCharacter> : BaseEntity<TCharacter> where TCharacter : ICharacter
    {
        private int Health { get; set; }
        int Velocity { get; set; }
        public Character(Texture2D texture, Rectangle form, SoundEffect sound, int health, Vector2 position)
        {
            this.Texture = texture;
            this.Form = form;
            this.Sound = sound;
            this.Health = health;
            this.Velocity = 10;
            this.Position = position;
        }

        public Character(Texture2D texture, Rectangle form, int health, Vector2 position, Color color)
        {
            this.Texture = texture;
            this.Form = form;
            this.Health = health;
            this.Velocity = 10;
            this.Position = position;
            this.Color = color;
        }

        public override void Update()
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
