namespace MobyDick.Core
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    interface IRenderable
    {
        Texture2D Texture { get; set; }
        Color Color { get; set; }
        Rectangle Form { get; set; }
        Vector2 Position { get; set; }
    }
}
