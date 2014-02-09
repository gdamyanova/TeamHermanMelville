namespace MobyDick.Entities.Interactable.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    internal class BaseItem: BaseEntity<BaseItem>, IItem
    {
        public ItemType Type { get; set; }
        public BaseItem (Texture2D texture, Rectangle form, Vector2 position, Color color, ItemType type)
            : base(texture, form, position, color)
        {
            this.Type = type;
        }
    }
}
