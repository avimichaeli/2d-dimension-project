// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Exceptions;
using GraphicsEx2.Shapes;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GraphicsEx2
{
    public static class Utils
    {
        
        public static FileContentAndPath LoadFile()
        {
            // define linked lists for lines, cicles and bezier curves, and a path to load the currect file //

            List<Line> lines = new List<Line>();
            List<Circle> circles = new List<Circle>();
            List<Bezier> beziers = new List<Bezier>();
            string path = "";

            // a counters to know how much lines , circles and beziers are in the data //
            int circlesCount = 0, bezierCount = 0, linesCount = 0;

           
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    path = filePath;
                    string[] linesFile = File.ReadAllLines(filePath);

                    // check how much lines circles and bezier curves are in the text file of the world coordinates //
                    // put the lines , circles  and bezier curves in the currect linked lists //
                    for (int i = 0; i < linesFile.Length; i++)
                    {
                        string line = linesFile[i].ToLower().Substring(0, linesFile[i].Length);
                        int indexOfBracket = line.IndexOf('[');
                        line = line.Substring(indexOfBracket + 1, line.Length - indexOfBracket - 1);
                        line = line.Substring(0, line.Length - 1);
                        string[] valus = line.Split(':');
                        if (linesFile[i].ToLower().Contains("line"))
                        {
                            linesCount++;
                            MyPoint start = null, end = null;
                            for (int j = 0; j < valus.Length; j++)
                            {
                                string[] coordinates = valus[j].Split(',');
                                if (j == 0)
                                    start = new MyPoint() { X = float.Parse(coordinates[0]), Y = float.Parse(coordinates[1]) };
                                else
                                    end = new MyPoint() { X = float.Parse(coordinates[0]), Y = float.Parse(coordinates[1]) };

                            }
                            lines.Add(new Line() { Start = start, End = end });

                        }
                        else if (linesFile[i].ToLower().Contains("circle"))
                        {
                            circlesCount++;
                            int raduis = int.Parse(valus[1]);
                            int indexOfP = line.IndexOf(':');
                            line = line.Substring(0, indexOfP);
                            string[] coordinates = line.Split(',');
                            MyPoint center = new MyPoint() { X = float.Parse(coordinates[0]), Y = float.Parse(coordinates[1]) };
                            circles.Add(new Circle() { R = raduis, Center = center });
                        }
                        else if (linesFile[i].ToLower().Contains("bezier"))
                        {
                            bezierCount++;
                            MyPoint p1 = null, p2 = null, p3 = null, p4 = null;
                            for (int j = 0; j < valus.Length; j++)
                            {
                                string[] coordinates = valus[j].Split(',');

                                for (int k = 0; k < coordinates.Length; k++)
                                {
                                    switch (j)
                                    {
                                        case 0: p1 = new MyPoint() { X = int.Parse(coordinates[0]), Y = int.Parse(coordinates[1]) }; break;
                                        case 1: p2 = new MyPoint() { X = int.Parse(coordinates[0]), Y = int.Parse(coordinates[1]) }; break;
                                        case 2: p3 = new MyPoint() { X = int.Parse(coordinates[0]), Y = int.Parse(coordinates[1]) }; break;
                                        case 3: p4 = new MyPoint() { X = int.Parse(coordinates[0]), Y = int.Parse(coordinates[1]) }; break;
                                    }
                                }
                            }

                            beziers.Add(new Bezier { P1 = p1, P2 = p2, P3 = p3, P4 = p4 });
                        }
                      
                    }

                    // between lines 101 - 108 there are 2 exceptions , the " NotAllShapesExsist " exception //
                    // and the "NorEnoughtEleentsExeption //
                    if (circlesCount + linesCount + bezierCount < 16)
                        throw new NotEnoughElementsExecption("ERROR: The file must contain at least 16 elements");
                    if (circlesCount == 0)
                        throw new NotAllShapesExistException("ERROR: There is not circles in the file");
                    if (linesCount == 0)
                        throw new NotAllShapesExistException("ERROR: There is not lines in the file");
                    if (bezierCount == 0)
                        throw new NotAllShapesExistException("ERROR: There is not beziers in the file");

                }
            }

            return new FileContentAndPath() { Path = path, Circles = circles, Lines = lines, Beziers = beziers };
        }


        public static void Draw(FileContentAndPath fc, Graphics graphics, int panelHeight, int panelWidth)
        {
            // create an axis origin in the screen //
            int delteX = panelWidth / 2;
            int delteY = panelHeight / 2;


            Pen whitePen = new Pen(Color.White, 1);
            List<Line> lines = fc.Lines;
            List<Circle> circles = fc.Circles;
            List<Bezier> beziers = fc.Beziers;
            // drawing the lines //
            for (int i = 0; i < lines.Count; i++)
                    graphics.DrawLine(whitePen, lines[i].Start.X + delteX, lines[i].Start.Y + delteY, lines[i].End.X + delteX, lines[i].End.Y + delteY);
               
            // drawing the circles //
            for (int i = 0; i < circles.Count; i++)
                graphics.DrawEllipse(whitePen, circles[i].Center.X + delteX, circles[i].Center.Y + delteY, circles[i].R * 2, circles[i].R * 2);
           
            // drawing the bezier curves //
            for (int i = 0; i < beziers.Count; i++)
            {
                graphics.DrawBezier(whitePen, 
                    beziers[i].P1.X+ delteX, beziers[i].P1.Y + delteY, 
                    beziers[i].P2.X + delteX, beziers[i].P2.Y + delteY,
                    beziers[i].P3.X + delteX, beziers[i].P3.Y + delteY,
                    beziers[i].P4.X + delteX, (int)beziers[i].P4.Y + delteY);
            }


            // drawing the x axis and y axis.
            Pen balackPen = new Pen(Color.Black, 1);
            // axis x //
            graphics.DrawLine(balackPen, 0, delteY, panelWidth, delteY);
            // axis y //
            graphics.DrawLine(balackPen, delteX, 0, delteX, panelHeight);
        }


    }
}
