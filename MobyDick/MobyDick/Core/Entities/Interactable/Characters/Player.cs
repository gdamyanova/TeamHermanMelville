namespace MobyDick.Entities.Interactable.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Entities.Interactable.Items;
    using System.Collections.Generic;
    internal class Player : Character, IPlayer
    {
        public void HandleItemPickup(object item)
        {
            var entity = item as BaseItem;
            this.BackPack.Add(entity);
        }
        public List<BaseItem> BackPack { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public Player(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, health, velocity, position, color, spriteBatch)
        {
            this.BackPack = new List<BaseItem>(10);
        }
        private void LevelUp()
        {
            this.Level++;
        }

        public void GainExperience(int experience = 1)
        {
            if (this.Experience + experience >= 100)
            {
                this.LevelUp();
                this.Experience = this.Experience - 100 + experience;
            }
            else
            {
                this.Experience += experience;
            }
        }
    }
}
