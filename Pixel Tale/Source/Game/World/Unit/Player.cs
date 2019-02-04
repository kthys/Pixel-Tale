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
    public class Player : Unit //inheritance from Unit
    {
        public Player(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }
        public override void Update(Vector2 OFFSET)
        {

            bool checkScroll = false;

            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed, pos.Y);
                checkScroll = true;
            }

            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
                checkScroll = true;
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
                checkScroll = true;
            }

            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
                checkScroll = true;
            }

            if (checkScroll)
            {
                GameGlobals.CheckScroll(pos);
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET);


            if (Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X, pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET)); //forced to set a new vector2 or the pos will update the player and the player will move
            }

            base.Update(OFFSET);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
