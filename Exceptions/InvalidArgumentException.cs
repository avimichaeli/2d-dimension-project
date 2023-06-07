// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this exception is in the translation transformation , it appears also in the gui - ( "form1.cs "). if in the translation exception //
// in the values of tx and ty the number is above 400 , or the number is negetive , an exception will apper on screen //

namespace GraphicsEx2.Exceptions
{
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string message) : base(message)
        {

        }
    }
}
