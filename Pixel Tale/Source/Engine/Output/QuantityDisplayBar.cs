#region Includes
using Microsoft.Xna.Framework;
#endregion

namespace Pixel_Tale
{
    public class QuantityDisplayBar
    {
        public int boarder;

        public Basic2d bar, barBKG;

        public Color color;

        public QuantityDisplayBar(Vector2 DIMS, int BOARDER, Color COLOR)
        {
            boarder = BOARDER;
            color = COLOR;

            bar = new Basic2d("UI/solid", new Vector2(0,0), new Vector2(DIMS.X - boarder *2, DIMS.Y - boarder * 2));
            barBKG = new Basic2d("UI/shade", new Vector2(0, 0), new Vector2(DIMS.X, DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT/MAX*(barBKG.dims.X - boarder*2), bar.dims.Y); // Current / max to get percentage of completion
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            barBKG.Draw(OFFSET, new Vector2(0,0), Color.Black);
            bar.Draw(OFFSET + new Vector2(boarder, boarder), new Vector2(0,0), color);
        }
    }
}
