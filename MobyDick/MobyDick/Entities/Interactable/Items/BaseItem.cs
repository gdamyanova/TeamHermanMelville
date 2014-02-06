using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobyDick.Entities;

namespace MobyDick.Entities.Interactable.Items
{
    internal abstract class BaseItem<TItem> : BaseEntity<TItem> where TItem : IItem
    {
    }
}
