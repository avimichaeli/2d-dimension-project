// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// a data check exception , if int data of the world coordinates there is not at least one line , one circle , and one bezier curve //
// an exception will apper on screen //

namespace GraphicsEx2.Exceptions
{
    public class NotAllShapesExistException : Exception
    {
        public NotAllShapesExistException(string message) : base(message)
        {

        }
    }
}
