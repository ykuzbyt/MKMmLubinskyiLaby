using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalaizerClass;

namespace calc.ClientSide
{
    public class CommonUtilities
    {

        public static string ProcessResult( string expression)
        {
            // Here analaizer class will be called
            return Analize.Start(expression);
        }
    }
}
