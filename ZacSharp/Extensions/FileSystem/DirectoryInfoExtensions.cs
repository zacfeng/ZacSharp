using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.IO;

namespace ZacSharp
{
    public static class DirectoryInfoExtensions
    {

        public static bool HasSubfiles(this DirectoryInfo dinfo)
        {
            bool checkResult = false;
            if (dinfo.GetFiles().Length > 0)
            {
                checkResult = true;
            }
            return checkResult;
        }

        public static bool HasSubDirectory(this DirectoryInfo dinfo)
        {
            bool checkResult = false;
            if (dinfo.GetDirectories("*", SearchOption.AllDirectories).Length > 0)
            {
                checkResult = true;
            }
            return checkResult;
        }

        public static bool IsEmptyDirectory(this DirectoryInfo dinfo)
        {
            return (HasSubfiles(dinfo) || HasSubDirectory(dinfo));
        }
        

    }
}
