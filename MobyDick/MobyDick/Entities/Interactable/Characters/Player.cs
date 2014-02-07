using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using MobyDick.Entities.Interactable.Characters;
using MobyDick.Entities.Interactable.Items;

namespace MobyDick.Entities.Interactable.Characters
{
    class Player<TPlayer> : Character<TPlayer> where TPlayer : ICharacter
    {
        private List<ItemType> BackPack;
        public Player(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, health, velocity, position, color, spriteBatch)
        {
            this.BackPack = new List<ItemType>(10);
        }
    }
}
