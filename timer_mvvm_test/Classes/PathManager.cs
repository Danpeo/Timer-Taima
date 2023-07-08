using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timer_mvvm_test.Classes
{
    class PathManager
    {
        public static string GetRelativePath(string folderName, string fileName)
        {
            string fullPath = Path.GetFullPath($@"{folderName}\{fileName}");
            string baseDirectory = Directory.GetCurrentDirectory();

            string relativePath = Path.GetRelativePath(baseDirectory, fullPath);
            return relativePath;
        }
    }
}
