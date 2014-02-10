namespace MobyDick.Core.Entities.Interactable
{
    public delegate bool EventHandler (object sender);
    interface IInteractable
    {
        bool HandleMoveCollision(bool MoveAllowed);
        event EventHandler MoveEvent;
    }
}
