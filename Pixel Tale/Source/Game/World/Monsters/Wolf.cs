#region Includes
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
    public class Wolf : Monster //inheritance from Monster
    {
       
        public Wolf(Vector2 POS) : base("Sprites/Monsters/Imp", POS, new Vector2(40,40))
        {
            
        }
        public override void Update(Vector2 OFFSET, Player PLAYER)
        {
            
            base.Update(OFFSET, PLAYER);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
