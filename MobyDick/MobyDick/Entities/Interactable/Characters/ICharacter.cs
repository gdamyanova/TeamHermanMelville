﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;


namespace MobyDick.Entities.Interactable.Characters
{
    interface ICharacter : IEntity
    {
        int Health { get; set; }
        int Velocity { get; set; }
    }
}
