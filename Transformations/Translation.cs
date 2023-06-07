// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Shapes;
using System.Collections.Generic;

namespace GraphicsEx2.Transformations
{
    public class Translation
    {
        public void Translate(int tx, int ty, FileContentAndPath fc)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Start.X += tx;
                lines[i].Start.Y += ty;

                lines[i].End.X += tx;
                lines[i].End.Y += ty;
            }

            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Center.X += tx;
                circles[i].Center.Y += ty;
            }

            for (int i = 0; i < beziers.Count; i++)
            {
                beziers[i].P1.X += tx;
                beziers[i].P1.Y += ty;

                beziers[i].P2.X += tx;
                beziers[i].P2.Y += ty;

                beziers[i].P3.X += tx;
                beziers[i].P3.Y += ty;

                beziers[i].P4.X += tx;
                beziers[i].P4.Y += ty;
            }
        }
    }
}
