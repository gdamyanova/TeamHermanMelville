namespace MobyDick.Core.Entities.Interactable.Items
{
    interface IItem : IEntity
    {
        ItemType Type { get; set; }
    }
}
