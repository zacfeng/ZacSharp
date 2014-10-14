using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ZacSharp.Utilities
{
    class DirectoryUtilities
    {

        /// <summary>
        /// create directory if dirName do not exist
        /// </summary>
        public static void CheckDirectory(string filePath)
        {
            string dirName = Path.GetDirectoryName(filePath);

            while (!Directory.Exists(dirName))
            {
                DirectoryUtilities.CheckDirectory(dirName);
                Directory.CreateDirectory(dirName);
            }
        }

        public static void ClearDirectory(string folderName)
        {
            string[] files = Directory.GetFiles(folderName);
            string[] dirs = Directory.GetDirectories(folderName);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                ClearDirectory(dir);
            }
            Directory.Delete(folderName, false);
        }

        public static void CopyDirectory(string srcDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dirInfo = new DirectoryInfo(srcDirName);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();

            if (!dirInfo.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + srcDirName);
            }

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    CopyDirectory(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
