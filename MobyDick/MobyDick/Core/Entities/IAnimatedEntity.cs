namespace MobyDick.Entities
{
    using Microsoft.Xna.Framework.Graphics;
    interface IAnimatedEntity : IEntity
    {
        float Timer { get; set; }
        float Interval { get; set; }
        int CurrentFrameNumber { get; set; }
        int MaxFrames { get; set; }
        SpriteBatch spriteBatch { get; set; }
        SpriteEffects Effect { get; set; }
        int SpriteRows { get; set; }

    }
}
