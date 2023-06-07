// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEx2.Transformations
{
    class Scaling
    {
        public void Scale(FileContentAndPath fc,float sx,float sy,MyPoint point)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;

            // the scaling tranformation actualize by the equation x = x*sx //
            // the scaling tranformation actualize by the equation y = y*sy //
            // in addition the variables point.x and point.y in the for loops is to actualize the scaling tranformation to a spesific point on the screen // 

            // scale the lines //

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Start.X =  lines[i].Start.X*sx + point.X;
                lines[i].Start.Y = lines[i].Start.Y*sy + point.Y;

                lines[i].End.X =  lines[i].End.X*sx + point.X;
                lines[i].End.Y = lines[i].End.Y * sy + point.Y;
            }
            // scale rhe circles //
            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Center.X = circles[i].Center.X*sx + point.X;
                circles[i].Center.Y = circles[i].Center.Y*sy + point.Y;
                circles[i].R = circles[i].R * (int)sx;
            }
            // scale the bezier curves //
            for (int i = 0; i < beziers.Count; i++)
            {

                beziers[i].P1.X = beziers[i].P1.X*sx + point.X;
                beziers[i].P2.X = beziers[i].P2.X*sx + point.X;
                beziers[i].P3.X = beziers[i].P3.X*sx + point.X;
                beziers[i].P4.X = beziers[i].P4.X*sx + point.X;

                beziers[i].P1.Y = beziers[i].P1.Y*sy + point.Y;
                beziers[i].P2.Y = beziers[i].P2.Y*sy + point.Y;
                beziers[i].P3.Y = beziers[i].P3.Y*sy + point.Y;
                beziers[i].P4.Y = beziers[i].P4.Y*sy + point.Y;


            }
        }
    }
}
