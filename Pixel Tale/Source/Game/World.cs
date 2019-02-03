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
        public int numKilled;

        public Vector2 offset;

        public Player player;

        public UI ui;

        public List<Projectile2d> projectiles = new List<Projectile2d>(); // Create the list of projectiles
        public List<Monster> monsters = new List<Monster>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        public World()
        {
            numKilled = 0;

            player = new Player("Sprites/Player/Player", new Vector2(300, 300), new Vector2(64, 64));

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMonster = AddMonster;
        

            offset = new Vector2(0, 0);

            spawnPoints.Add(new SpawnPoint("Sprites/Misc/circle", new Vector2(50, 50), new Vector2(35, 35)));

            spawnPoints.Add(new SpawnPoint("Sprites/Misc/circle", new Vector2(Globals.screenWidth / 2, 50), new Vector2(35, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            spawnPoints.Add(new SpawnPoint("Sprites/Misc/circle", new Vector2(Globals.screenWidth - 50, 50), new Vector2(35, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

            ui = new UI();
        }
        public virtual void Update()
        {

            player.Update(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, monsters.ToList<Unit>());
                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Update(offset, player);
                if (monsters[i].dead)
                {
                    monsters.RemoveAt(i);
                    numKilled++;
                    i--;
                }
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(offset);

            }

            ui.Update(this);


        }

        public virtual void AddMonster(object INFO)
        {
            monsters.Add((Monster)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            player.Draw(offset);
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);
            }

            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Draw(offset);
            }

            ui.Draw(this);

        }
    }
}
