using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class StorageHelper
    {
        private static readonly string AppFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "NazwaAplikacji"
        );
        public static string GetFilePath(string fileName)
        {
            Directory.CreateDirectory(AppFolder);
            return Path.Combine(AppFolder, fileName);
        }
    }

}

