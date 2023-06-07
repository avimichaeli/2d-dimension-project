// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// if there is not at least 16 elements in the data of the world coordinates , an exception will apper on screen //

namespace GraphicsEx2.Exceptions
{
   public class NotEnoughElementsExecption:Exception
    {
        public NotEnoughElementsExecption(string message):base(message)
        {
                
        }
    }
}
