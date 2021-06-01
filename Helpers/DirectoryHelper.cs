using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSense.Helpers
{
    /// <summary>
    /// Class helps to retrive path to appdata folder and esnure folder exists
    /// </summary>
    public class DirectoryHelper
    {
        private string mAppDataPath;
        public string PathToAppData
        {
            get
            {
                return mAppDataPath;
            }
        }
        public DirectoryHelper()
        {
            string filePath;
            mAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            filePath = Path.Combine(PathToAppData, "Snake", "Snake");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
    }
}
