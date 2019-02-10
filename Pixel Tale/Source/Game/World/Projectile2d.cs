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
    public class Projectile2d : Basic2d
    {
        public bool done;
        public float speed;
        public Vector2 direction;
        public Unit owner;
        public GameTimer timer;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) //change target to Unit if the projectile has a designated target
            : base(PATH, POS, DIMS)
        {
            done = false;
            speed = 5.0f;
            owner = OWNER;
            direction = TARGET - owner.pos;
            direction.Normalize();

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));


        timer = new GameTimer(1200);
        }

        public virtual void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            pos += direction * speed;

            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }
            if (CollisionTest(UNITS))
            {
                done = true;
            }

        }
        public virtual bool CollisionTest(List<Unit> UNITS)
        {
            for(int i = 0; i<UNITS.Count; i++)
            {
                if(Globals.GetDistance(pos,UNITS[i].pos) < UNITS[i].hitDist) //if the distance between the projectile and the unit is smaller than the unit hit distance
                {
                    UNITS[i].GetHit(1);
                    return true;
                }
            }

            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
