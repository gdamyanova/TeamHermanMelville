namespace MobyDick.Entities.Interactable.Items
{
    interface IItem : IEntity
    {
        ItemType Type { get; set; }
    }
}
