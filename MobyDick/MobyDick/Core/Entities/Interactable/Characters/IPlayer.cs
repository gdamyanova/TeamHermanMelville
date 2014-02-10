namespace MobyDick.Entities.Interactable.Characters
{
    using MobyDick.Entities.Interactable.Items;
    using System.Collections.Generic;
    interface IPlayer
    {
        int Level { get; }
        int Experience { get; }
        List<BaseItem> BackPack { get; }
        void HandleItemPickup(object item);
    }
}
