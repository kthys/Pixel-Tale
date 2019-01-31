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
    public class World
    {
        public Vector2 offset;
        public Player player;
        public List<Projectile2d> projectiles = new List<Projectile2d>(); // Create the list of projectiles

        public World()
        {
            player = new Player("Sprites/Player/Player", new Vector2(300, 300), new Vector2(64,64));

            GameGlobals.PassProjectile = AddProjectile;

            offset = new Vector2(0, 0);
        }
        public virtual void Update()
        {
            player.Update();

            for(int i=0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);
                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            player.Draw(OFFSET);
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }
}
