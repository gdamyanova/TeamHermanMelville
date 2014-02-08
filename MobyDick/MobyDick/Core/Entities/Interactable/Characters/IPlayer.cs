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
    interface IPlayer
    {
        int Level { get; }
        int Experience { get; }
        List<ItemType> BackPack { get; }
    }
}
