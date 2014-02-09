namespace MobyDick.Entities.Interactable.Characters
{
    interface ICharacter : IAnimatedEntity
    {
        int Health { get; }
        int Velocity { get;}

    }
}
