using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pixel_Tale
{
    public class Basic2d
    {
        public Vector2 pos, dims;
        public Texture2D myModel;

        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X), (int)(pos.Y), (int)dims.X, (int)dims.Y), null,Color.White, 0.0f, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height/2), new SpriteEffects(), 0); // Null in the middle allow to only use a region of the sprite
                // Bounds are from the middle, that's why it's divided by 2

            }
        }
    }
}
