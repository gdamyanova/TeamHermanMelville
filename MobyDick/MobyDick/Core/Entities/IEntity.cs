namespace MobyDick.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    interface IEntity
    {
        Texture2D Texture { get;  set; }
        Color Color { get;  set; }
        Rectangle Form { get; set; }
        Vector2 Position { get; set; }
        Rectangle BoundingBox { get; }
    }
}
