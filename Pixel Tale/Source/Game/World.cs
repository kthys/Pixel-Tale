﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion


namespace Pixel_Tale
{
    public class World
    {
        public Player player;

        public World()
        {
            player = new Player("Sprites/Player", new Vector2(300, 300), new Vector2(64,64));
        }
        public virtual void Update()
        {
            player.Update();
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            player.Draw(OFFSET);
        }
    }
}
