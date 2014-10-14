using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ZacSharp.Extensions.FileSystem
{
    class PathExtensions
    {
        public static bool IsDirectory(string path)
        {
            bool checkResult = false;
            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                checkResult = true;
            }
            return checkResult;
        }
    }
}
