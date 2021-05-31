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
        private string mFilePath;
        private string mAppDataPath;
        public string PathToAppData
        {
            set
            {
                mAppDataPath = value;
            }
            get
            {
                return mAppDataPath;
            }
        }
        public DirectoryHelper()
        {
            PathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            mFilePath = Path.Combine(PathToAppData, "Snake", "Snake");
            Directory.CreateDirectory(Path.GetDirectoryName(mFilePath));
        }
    }
}
