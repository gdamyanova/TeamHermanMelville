namespace MobyDick.Core.Entities.Interactable.Characters
{
    using MobyDick.Core.Entities.Interactable.Items;
    using System.Collections.Generic;
    interface IPlayer
    {
        int Level { get; }
        int Experience { get; }
        List<BaseItem> BackPack { get; }
        void HandleItemPickup(object item);
    }
}
