namespace MobyDick.Core.Entities.Interactable.Items
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Core.Entities;
    internal delegate void ItemAction(object entity);
    internal class BaseItem : BaseEntity<BaseItem>, IItem
    {
        public ItemType Type { get; set; }
        private ItemAction UseItem;
        public BaseItem (Texture2D texture, Rectangle form, Vector2 position, Color color, ItemType type)
            : base(texture, form, position, color)
        {
            this.Type = type;
        }

        public void AddUsage(ItemAction func)
        {
            this.UseItem = func;
        }

        public void Use(object entity)
        {
            this.UseItem(entity);
        }
    }
}
