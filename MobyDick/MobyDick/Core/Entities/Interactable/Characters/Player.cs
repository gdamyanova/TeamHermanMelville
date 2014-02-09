namespace MobyDick.Entities.Interactable.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Entities.Interactable.Items;
    using System.Collections.Generic;
    internal class Player : Character, IPlayer
    {
        public List<ItemType> BackPack { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public Player(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, health, velocity, position, color, spriteBatch)
        {
            this.BackPack = new List<ItemType>(10);
        }
        private void LevelUp()
        {
            this.Level++;
            this.Experience = 0;
        }
    }
}
