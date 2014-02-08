using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MobyDick.Entities.Interactable.Items
{
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
