using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LamApi
{
    class FileTools
    {
        public static void Rename(string oldFilename, string newFilename, bool removeOldFilename)
        {
            if (File.Exists(oldFilename))
            {
                File.Copy(oldFilename, newFilename);
                if (removeOldFilename)
                {
                    File.Create(oldFilename);
                }
            }
        }

    } // end class FileTools
}
