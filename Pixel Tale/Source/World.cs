using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pixel_Tale
{
    public class World
    {
        public Basic2d Player;
        public World()
        {
            Player = new Basic2d("Sprites/Player", new Vector2(300, 300), new Vector2(48,48));
        }
        public virtual void Update()
        {
            Player.Update();
        }
        public virtual void Draw()
        {
            Player.Draw();
        }
    }
}
