using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
namespace MobyDick.Entities
{
    interface IEntity
    {
        Texture2D Texture { get;  set; }
        Color Color { get;  set; }
        Rectangle Form { get; set; }
        Vector2 Position { get; set; }
        //void Update();
        //void Draw();
        //void Initialize();
    }
}
