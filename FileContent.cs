// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Shapes;
using System.Collections.Generic;

namespace GraphicsEx2
{
    // define the lines circles and bezier curves //
    // put the grapihc shapes into proper linked list //
    // define a path to open the file //
    public class FileContentAndPath
    {
        public List<Line> Lines { get; set; }
        public List<Circle> Circles { get; set; }
        public List<Bezier> Beziers { get; set; }
        public string Path { get; set; }
    }
}
