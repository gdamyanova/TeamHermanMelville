using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobyDick.Entities.Interactable.Items
{
    interface IItem : IEntity
    {
        ItemType Type { get; set; }
    }
}
