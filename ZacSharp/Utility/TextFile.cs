using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ZacSharp.Utility
{
    public static class TextFile
    {
        /// <summary>
        /// Read text file into a string and return.
        /// </summary>
        /// <param name="srcFilePath">the source file path you want to read.</param>
        /// <returns>string type content</returns>
        public static string ReadTextFile(string srcFilePath)
        {
            string output = string.Empty;
            if (System.IO.File.Exists(srcFilePath))
            {
                output = System.IO.File.ReadAllText(srcFilePath);
            }
            else
            {
                throw new System.IO.FileNotFoundException();
            }
            return output;
        }

        /// <summary>
        /// Read text file into a string and return.
        /// </summary>
        /// <param name="srcFilePath">the source file path you want to read.</param>
        /// <returns>string type content</returns>
        public static string ReadTextFileWithRetry(string srcFilePath, bool waitReady = false)
        {
            string output = string.Empty;
            if (System.IO.File.Exists(srcFilePath))
            {
                try
                {
                    if (waitReady==true) while (!WaitReady(srcFilePath)) { }
                    output = System.IO.File.ReadAllText(srcFilePath);
                }
                catch (IOException ioex)
                {
                    throw new IOException(string.Format("讀取檔案發生錯誤：{0}", ioex.Message));
                }
            }
            else
            {
                throw new System.IO.FileNotFoundException();
            }
            return output;
        }

        /// <summary>
        /// FileSystemWatcher thread would lock file after Onchange event has been trigger, 
        /// </summary>
        /// <param name="srcFilePath"></param>
        /// <returns></returns>
        private static bool WaitReady(string srcFilePath)
        {
            int i = 0;
            bool bResult = false;
            while (i < 20)//Retry 20次
            {
                try
                {
                    using (Stream stream = System.IO.File.Open(srcFilePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        if (stream != null)
                        {
                            Console.WriteLine(string.Format("檔案 {0} ready.", srcFilePath));
                            bResult = true;
                            break;
                        }
                    }
                }
                catch (FileNotFoundException ex){bResult = false;}
                catch (IOException ex){bResult = false;}
                catch (UnauthorizedAccessException ex){bResult = false;}
                finally
                {
                    i++;
                    System.Threading.Thread.Sleep(500);
                }
            }
            return bResult;
        }

        /// <summary>
        /// write text to the file.
        /// </summary>
        /// <param name="targetFilePath">The file path you want to save.</param>
        /// <param name="content">Write string.</param>
        public static void WriteTextFile(string targetFilePath, string content)
        {
            System.IO.FileInfo f = new System.IO.FileInfo(targetFilePath);
            if (!f.Directory.Exists)
            {
                f.Directory.CheckDirectory();
            }

            if (content != string.Empty && targetFilePath != string.Empty)
                System.IO.File.WriteAllText(targetFilePath, content);
        }
        

        /// <summary>
        /// Append text to the buttom of file.
        /// </summary>
        /// <param name="targetFilePath">The file path you want to save.</param>
        /// <param name="content">Appended string.</param>
        public static void AppendTextFile(string targetFilePath, string content)
        {
            if (content != string.Empty && targetFilePath != string.Empty)
                System.IO.File.AppendAllText(targetFilePath, content);
        }
    }
}
