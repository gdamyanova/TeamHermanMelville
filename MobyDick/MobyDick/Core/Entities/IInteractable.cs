namespace MobyDick.Core.Entities
{
    public delegate bool EventHandler (object sender);
    interface IInteractable
    {
        bool HandleCollision(bool MoveAllowed);
        event EventHandler MoveEvent;
    }
}
