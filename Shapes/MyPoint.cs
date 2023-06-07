// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using System.Drawing;
// define point , the point will be with two values , x , and y , those points will be a part of a anther graphic shapes //

namespace GraphicsEx2.Shapes
{
    public class MyPoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point ToPoint()
        {
            return new Point((int)X,(int)Y);
        }
    }
}
