using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZacSharp.Exceptions
{
    class UnhandledException : Exception
    {
        public UnhandledException()
        :base()
        {;}

        public UnhandledException(string message)
        :base(message)
        {;}

        public UnhandledException(string message, Exception inner)
        : base(message, inner)
        {;}
    }
}
