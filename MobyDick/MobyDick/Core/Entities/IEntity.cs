namespace MobyDick.Core.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Core;
    
    interface IEntity : IRenderable, IInteractable
    {
        Rectangle BoundingBox { get; }
    }
}
