using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace ZacSharp
{
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// create directory if dirName do not exist
        /// </summary>
        public static void CheckDirectory(this System.IO.DirectoryInfo dirinfo)
        {
            if (!System.IO.Directory.Exists(dirinfo.FullName))
            {
                System.IO.Directory.CreateDirectory(dirinfo.FullName);
            }
        }
    }
}
