// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Shapes;
using System;
using System.Collections.Generic;

namespace GraphicsEx2.Transformations
{
    public class Rotation
    {

        public void Rotate(FileContentAndPath fc,double angle,MyPoint point)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;
            angle = Math.PI * angle / 180.0;

            // defines the variable for the rotator transformation //

            float dx = point.X;
            float dy = point.Y;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            // the trigonometric equation X'=(X-dx)*cos(t)-(Y-dy)*sin+dx //
            // the trigonometric equation Y'=(X-dx)*sin+(y-dy)*cos+dy //

            // rotate the lines //

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Start.X = (lines[i].Start.X - dx) * cos - (lines[i].Start.Y  -dy) * sin + dx;
                lines[i].Start.Y = (lines[i].Start.X - dx) * sin + (lines[i].Start.Y - dy) * cos + dy;

                lines[i].End.X = (lines[i].End.X - dx) * cos - (lines[i].End.Y - dy) * sin + dx;
                lines[i].End.Y = (lines[i].End.X - dx) * sin + (lines[i].End.Y - dy) * cos + dy;
            }

            // rotate the circles //
            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Center.X = (circles[i].Center.X - dx) * cos - (circles[i].Center.Y - dy) * sin + dx;
                circles[i].Center.Y = (circles[i].Center.X - dx) * sin + (circles[i].Center.Y - dy) * cos + dy;
            }
            // rotate the bezier curves//
            for (int i = 0; i < beziers.Count; i++)
            {
                beziers[i].P1.X = (beziers[i].P1.X - dx) * cos - (beziers[i].P1.Y - dy) * sin + dx;
                beziers[i].P1.Y = (beziers[i].P1.X - dx) * sin + (beziers[i].P1.Y - dy) * cos + dy;

                beziers[i].P2.X = (beziers[i].P2.X - dx) * cos - (beziers[i].P2.Y - dy) * sin + dx;
                beziers[i].P2.Y = (beziers[i].P2.X - dx) * sin + (beziers[i].P2.Y - dy) * cos + dy;

                beziers[i].P3.X = (beziers[i].P3.X - dx) * cos - (beziers[i].P3.Y - dy) * sin + dx;
                beziers[i].P3.Y = (beziers[i].P3.X - dx) * sin + (beziers[i].P3.Y - dy) * cos + dy;

                beziers[i].P4.X = (beziers[i].P4.X - dx) * cos - (beziers[i].P4.Y - dy) * sin + dx;
                beziers[i].P4.Y = (beziers[i].P4.X - dx) * sin + (beziers[i].P4.Y - dy) * cos + dy;
            }
        }
    }
}
