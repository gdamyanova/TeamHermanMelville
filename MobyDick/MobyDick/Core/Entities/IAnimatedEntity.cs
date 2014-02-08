using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MobyDick.Entities
{
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
