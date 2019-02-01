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
    public class Monster : Unit //inheritance from Unit
    {
       
        public Monster(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            
        }
        public virtual void Update(Vector2 OFFSET, Player PLAYER)
        {
            AI(PLAYER);
            base.Update(OFFSET);
        }

        public virtual void AI(Player PLAYER)
        {
            pos += Globals.RadialMovement(PLAYER.pos, pos, speed);
            rot = Globals.RotateTowards(pos, PLAYER.pos);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
