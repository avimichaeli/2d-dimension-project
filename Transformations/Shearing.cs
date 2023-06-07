// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEx2.Transformations
{
    public class Shearing
    {
        
        //x'=ay+x
        //y'=y
        public void SheareByX(FileContentAndPath fc, float a)
        {          
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;
            float ay;
            for (int i = 0; i < lines.Count; i++)
            {
                 ay = lines[i].Start.Y*a; 
                lines[i].Start.X += ay;

                ay = lines[i].End.Y * a;
                lines[i].End.X += ay;
            }

            for (int i = 0; i < circles.Count; i++)
            {
               
                ay = circles[i].Center.Y * a;
                circles[i].Center.X += ay;
            }

            for (int i = 0; i < beziers.Count; i++)
            {
                ay = beziers[i].P1.Y * a;
                beziers[i].P1.X += ay;

                ay = beziers[i].P2.Y * a;
                beziers[i].P2.X += ay;

                ay = beziers[i].P3.Y * a;
                beziers[i].P3.X += ay;

                ay = beziers[i].P4.Y * a;
                beziers[i].P4.X += ay;
            }
        }

        //y'=y+bx
        //x'=x
        public void SheareByY(FileContentAndPath fc, float b)
        {
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;
            float bx;
            for (int i = 0; i < lines.Count; i++)
            {
                bx = lines[i].Start.X * b;
                lines[i].Start.Y += bx;

                bx = lines[i].End.X * b;
                lines[i].End.Y+= bx;
            }

            for (int i = 0; i < circles.Count; i++)
            {

                bx = circles[i].Center.X * b;
                circles[i].Center.Y += bx;
            }

            for (int i = 0; i < beziers.Count; i++)
            {
                bx = beziers[i].P1.X * b;
                beziers[i].P1.Y += bx;

                bx = beziers[i].P2.X * b;
                beziers[i].P2.Y += bx;

                bx = beziers[i].P3.X * b;
                beziers[i].P3.Y += bx;

                bx = beziers[i].P4.X * b;
                beziers[i].P4.Y += bx;
            }
        }
    }
}
