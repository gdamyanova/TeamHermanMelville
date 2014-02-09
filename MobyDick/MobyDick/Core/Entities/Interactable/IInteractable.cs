namespace MobyDick.Core.Entities.Interactable
{
    public delegate void EventHandler (object item);
    interface IInteractable
    {
        void HandleCollision(object item);
    }
}
