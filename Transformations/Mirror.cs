// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Shapes;
using System.Collections.Generic;


namespace GraphicsEx2.Transformations
{
  public  class Mirror
    {
        // all the y values of all the lines, circles and bezier curves coordinates will be doubled by -1 //
        // the grphic object will do a mirror by axis x //

        public void MirrorByX(FileContentAndPath fc)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Start.Y *= (-1);
                lines[i].End.Y *= (-1);
            }

            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Center.Y *= (-1);
            }

            for (int i = 0; i < beziers.Count; i++)
            {
                beziers[i].P1.Y *= (-1);
                beziers[i].P2.Y *= (-1);
                beziers[i].P3.Y *= (-1);
                beziers[i].P4.Y *= (-1);
            }
        }

        // all the x values of all the lines, circles and bezier curves coordinates will be doubled by -1 //
        // the grphic object will do a mirror by axis y //

        public void MirrorByY(FileContentAndPath fc)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Start.X *= (-1);
                lines[i].End.X *= (-1);
            }

            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Center.X *= (-1);
            }

            for (int i = 0; i < beziers.Count; i++)
            {
                beziers[i].P1.X *= (-1);
                beziers[i].P2.X *= (-1);
                beziers[i].P3.X *= (-1);
                beziers[i].P4.X *= (-1);
            }
        }
        // all the x and y values of all the lines, circles and bezier curves coordinates will be doubled by -1 //
        // the grphic object will do a mirror by the axis origin //
        public void MirrorByAxis(FileContentAndPath fc)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Start.X *= (-1);
                lines[i].End.X *= (-1);

                lines[i].Start.Y *= (-1);
                lines[i].End.Y *= (-1);
            }

            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Center.X *= (-1);
                circles[i].Center.Y *= (-1);
            }

            for (int i = 0; i < beziers.Count; i++)
            {
                beziers[i].P1.X *= (-1);
                beziers[i].P2.X *= (-1);
                beziers[i].P3.X *= (-1);
                beziers[i].P4.X *= (-1);

                beziers[i].P1.Y *= (-1);
                beziers[i].P2.Y *= (-1);
                beziers[i].P3.Y *= (-1);
                beziers[i].P4.Y *= (-1);
            }
        }
    }
}
