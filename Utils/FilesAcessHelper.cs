using System;
using System.Collections.Generic;
using System.Text;

namespace eClavijoA.Utils
{
    public class FilesAcessHelper
    {
        public static string GetFileNameFromPath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory,filename);
        }
    }
}
