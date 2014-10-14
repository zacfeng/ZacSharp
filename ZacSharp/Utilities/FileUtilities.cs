using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ZacSharp.Extensions.FileSystem;

namespace ZacSharp.Utilities
{
    class FileUtilities
    {
        public static void FileDelete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void FileCopy(string srcFileName, string destFileName)
        {

            if (PathExtensions.IsDirectory(srcFileName)) //exit function if srcFileName is directory
            {
                return;
            }

            FileInfo finfo = new FileInfo(srcFileName);
            try
            {
                finfo.CopyTo(destFileName, true);
            }
            catch (DirectoryNotFoundException ex)
            {
                DirectoryUtilities.CheckDirectory(destFileName);
                finfo.CopyTo(destFileName, true);
            }

        }
    }
}
