using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            get => mAppDataPath;
            set => mAppDataPath = value;
        }

        public DirectoryHelper()
        {
            mAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String filePath = Path.Combine(PathToAppData, "Snake", "Snake");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException("Cant find folder 'Snake' in AppData"));
        }
    }
}
